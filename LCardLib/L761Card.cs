using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCardLib
{
    public class L761Card : ADCCard
    {
        static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        const int DefL761Slot = 0;
        const int DefL761Channel = 1;
        const int DefL761Amplification = 0x1;

        public uint Slot { get; private set; }
        public int Channel { get; private set; }
        public int Amplification { get; private set; }

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

            if (LCardApi.OpenSlot(Slot) && (LCardApi.OpenLDevice() != INVALID_HANDLE_VALUE))
            {
                /*
                 * // определить наличие карты
            if (OpenLDevice(FSlot + 50, @FDev) <> INVALID_HANDLE_VALUE) and
                   (ReadPlataDescr_PLX(@FDev, @FPlata_Desc, 0) <> 0) then begin
                // загрузить биос
                FPresent:= (PlataReset_PLX(@FDev, 0) <> 0);
                FPresent:= FPresent and(LoadBios(@FDev, @FPlata_Desc.BrdName, 0, 0) <> 0);
                FPresent:= FPresent and(PlataTest_PLX(@FDev, 0) <> 0);
            end;
                */
            }

            
            fReading = false;

            return IsPresent;
        }

        public override int ReadValue(bool stopCondition)
        {
            throw new NotImplementedException();
        }

        public override bool StartRead()
        {
            throw new NotImplementedException();
        }

        public override void StopCard()
        {
            throw new NotImplementedException();
        }

        public override void StopRead()
        {
            throw new NotImplementedException();
        }

        protected override string GetCardDescription()
        {
            throw new NotImplementedException();
        }

        protected override string GetCardName()
        {
            throw new NotImplementedException();
        }
    }
}
