using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LCardLib
{
    public enum L761Amplification
    {
        x1, x4, x16, x64
    }

    public class L761Card : ADCCard
    {
        const uint DefPointsToInt = 100;
        const int DefL761Slot = 0;
        const int DefL761Channel = 1;
        const L761Amplification DefL761Amplification = L761Amplification.x1;

        private WADC_PAR_0 FADC_Par;
        private PLATA_DESCR FPlata_Desc;
        private uint FBufferSize;
        private uint PrevSyncValue;
        private IntPtr FPSync;
        private IntPtr FPData;
        private uint FPackSize; // сколько отсчетов необходимо осреднять
        public uint Slot { get; private set; }
        public uint Channel { get; private set; }
        public L761Amplification Amplification { get; private set; }

        public L761Card() : base()
        {
            NumBits = 14;
            IsPresent = false;
            CalcMaxMinValues();

            Slot = DefL761Slot;
            Channel = DefL761Channel;
            Amplification = DefL761Amplification;
        }

        public override bool InitCard(int readFreq)
        {
            if (IsPresent) {
                StopCard();
            }

            IsPresent = false;
            Freq = readFreq;

            if (LCardApi.OpenSlot(Slot) && (LCardApi.OpenLDevice() != LCardApi.INVALID_HANDLE_VALUE))
            {
                this.IsPresent = 
                    LCardApi.ReadPlataDescr(out this.FPlata_Desc) & 
                    LCardApi.LoadBios(this.FPlata_Desc.BrdName) & 
                    LCardApi.PlataTest();
            }

            
            fReading = false;

            return IsPresent;
        }

        public override int ReadValue(bool stopCondition = false)
        {
            var Result = 0;
            if (!this.IsReading) {
                return 0;
            }
            
            // ждем окончания чтения
            var begSync = this.PrevSyncValue;
            var endSync = begSync + this.FPackSize - 1;
            if (endSync >= this.FBufferSize) {
                endSync = endSync - this.FBufferSize;
            }

            //  raise EADCCardException.CreateFmt('begSync %p endSync %p FBufferSize %x FPSync^ %x)!', [pointer(begSync), pointer(endSync), FBufferSize, FPSync^]);
            bool stop = false;
            long delta = 0;

            var Ticks = Environment.TickCount;
            do {
                System.Threading.Thread.Sleep(0);
                stop = stopCondition || (!this.IsReading);
                delta = (Marshal.ReadInt32(this.FPSync) - begSync);
                if (delta < 0) {
                    delta = delta + (int)this.FBufferSize;
                }

                var deltaTicks = Environment.TickCount;
                if (deltaTicks != Ticks) {
                    // по типу учитываем переполнение
                    if (deltaTicks > Ticks) {
                        deltaTicks = deltaTicks - Ticks;
                    } else {
                        deltaTicks = Int32.MaxValue - Ticks + deltaTicks;
                    }

                    if (deltaTicks > 2000) { // если крутимся больше 2х секунд
                        throw new Exception(string.Format("Ошибка чтения (Прочитано {0}, буфер {1})!", delta, this.FBufferSize));
                    }
                }
            } while (stop || (delta > this.FPackSize));
        
            if (stop) {
                return 0;
            }
        
            // отмечаем начало и конец буфера с данными
            this.PrevSyncValue = endSync + 1;
            var SumValue = 0;
            if (endSync < begSync) {
                // буфер завернулся, собираем из 2х половинок
                short[] dataArray1 = new short[FBufferSize - begSync];
                Marshal.Copy(this.FPData, dataArray1, (int)begSync, dataArray1.Length);

                short[] dataArray2 = new short[endSync + 1];
                Marshal.Copy(this.FPData, dataArray1, 0, (int)(endSync + 1));

                SumValue = dataArray1.Sum(x => x) + dataArray2.Sum(x => x);
            } else {
                short[] dataArray = new short[endSync - begSync + 1];
                Marshal.Copy(this.FPData, dataArray, 0, dataArray.Length);
                SumValue = dataArray.Sum(x => x);
            }
         
            // осреднить
            if (this.FPackSize > 0) {
                Result = (int)(SumValue / FPackSize);
            }

            return Result;
        }

        public override bool StartRead()
        {
            this.PrevSyncValue = 0;
            if ((!this.IsPresent) || this.IsReading) {
                return false;
            }

            this.IsReading = false;

            this.FADC_Par = new WADC_PAR_0
            {
                s_Type = LCardApi.L_ADC_PARAM,
                AutoInit = 1,
                dScale = 0,
                SynchroType = 3, // - тип синхронизации 3 - синхронизации нет
                SynchroSensitivity = 1, // - вид синхронизации
                SynchroMode = 1, // - режим синхронизации
                AdChannel = 0, // - канал синхронизации
                AdPorog = 128, // - уровень синхронизации
                NCh = 1 // - количество каналов участвующее в сборе данных
            };

            this.FADC_Par.Chn = new uint[128];
            this.FADC_Par.Chn[0] = this.Channel & 0x07;
            switch (this.Amplification) {
                case L761Amplification.x1:
                    this.FADC_Par.Chn[0] = this.FADC_Par.Chn[0] + 0x00;
                    break;
                case L761Amplification.x4:
                    this.FADC_Par.Chn[0] = this.FADC_Par.Chn[0] + 0x40;
                    break;
                case L761Amplification.x16:
                    this.FADC_Par.Chn[0] = this.FADC_Par.Chn[0] + 0x80;
                    break;
                case L761Amplification.x64:
                    this.FADC_Par.Chn[0] = this.FADC_Par.Chn[0] + 0xC0;
                    break;
            }

            var maxPackSize = DefPointsToInt * 20 / 10;
            var minPackSize = DefPointsToInt * 3 / 10;
            var minDelta = 1D;
            var bestPackSize = minPackSize;

            // вычислить FPackSize - подбираем так,
            // чтобы частота опроса была как можно ближе к требуемой
            for (uint i = minPackSize; i <= maxPackSize; i++) {
                var delta = Math.Abs((1000000 / (Freq * i)) - Math.Ceiling(1000000 / (Freq * i)));
                if (delta < minDelta)
                {
                    minDelta = delta;
                    bestPackSize = i;
                }
            }

            this.FPackSize = bestPackSize;
            this.FADC_Par.dRate = (Freq * FPackSize) / 1000; // в кГц
            this.FADC_Par.dKadr = 0;

            this.FADC_Par.FIFO = 0x400;
            this.FADC_Par.IrqStep = FPackSize;
            this.FADC_Par.Pages = 16;
            this.FADC_Par.IrqEna = 1;
            this.FADC_Par.AdcEna = 1;

            if (LCardApi.FillDAQparameters(ref this.FADC_Par, LCardApi.CASE_ADC_PAR_0))
            {
                this.FADC_Par.AutoInit = 1;  // указывает, что сбор данных циклический
                this.FPackSize = this.FADC_Par.IrqStep;
                this.Freq = this.FADC_Par.dRate * 1000D / FPackSize; // настоящая частота сбора данных
                this.FBufferSize = this.FADC_Par.IrqStep * FADC_Par.Pages * 16;
                this.IsReading = 
                    LCardApi.RequestBufferStream(ref this.FBufferSize, LCardApi.L_STREAM_ADC) &
                    LCardApi.SetParametersStream(ref this.FADC_Par, LCardApi.CASE_ADC_PAR_0, ref this.FBufferSize, ref this.FPData, ref this.FPSync, LCardApi.L_STREAM_ADC) &
                    LCardApi.InitStartLDevice() &
                    LCardApi.StartLDevice();

                if (this.IsReading)
                {
                    this.PrevSyncValue = (uint)Marshal.ReadInt32(this.FPSync);
                }

                return this.IsReading;
            }


            return false;
        }

        public override void StopCard()
        {
            if (this.IsPresent) { 
                if (this.IsReading)
                {
                    this.StopRead();
                }

                LCardApi.CloseLDevice();
                this.IsPresent = false;
            }
        }

        public override void StopRead()
        {
            if (this.IsReading)
            {
                LCardApi.StopLDevice();
                this.IsReading = false;
            }
        }

        protected override string GetCardDescription()
        {
            return "LCard L761";
        }

        protected override string GetCardName()
        {
            return "L761";
        }
    }
}
