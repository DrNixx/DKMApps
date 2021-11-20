using LCardLib;
using System;

namespace LCardDiags
{
    class Program
    {
        static void Main(string[] args)
        {
            var card = new L761Card();
            card.InitCard(1000);
            var start = card.StartRead();
            if (start)
            {
                for (var i = 0; i < 10; i++)
                {
                    var d = card.ReadValue()
                }

                card.StopRead();
            }


            /*
            LCardApi.OpenSlot(0);

            var h = LCardApi.OpenLDevice();
            Console.WriteLine("OpenLDevice Handle {0}", h);

            var err = LCardApi.LoadBios("l761");
            Console.WriteLine("LoadBios Status: {0}", err);

            var Err = LCardApi.PlataTest();

            Console.WriteLine("Plata test {0:X}", Err);

            Console.WriteLine("Slot parameters");

            LCardApi.GetSlotParam(out SLOT_PARAM sl);

            Console.WriteLine("Base    {0:X}", sl.Base);
            Console.WriteLine("BaseL   {0:X}", sl.BaseL);
            Console.WriteLine("Mem     {0:X}", sl.Mem);
            Console.WriteLine("MemL    {0:X}", sl.MemL);
            Console.WriteLine("Type    {0:X}", sl.BoardType);
            Console.WriteLine("DSPType {0:X}", sl.DSPType);
            Console.WriteLine("Irq     {0:X}", sl.Irq);

            Console.WriteLine("Press any key");
            Console.ReadKey();

            Console.WriteLine("Read FLASH");
            LCardApi.ReadPlataDescr(out PLATA_DESCR pd);
            Console.WriteLine("SerNum       {0}", pd.SerNum);
            Console.WriteLine("BrdName      {0}", pd.BrdName);
            Console.WriteLine("Rev          {0}", pd.Rev);
            Console.WriteLine("DspType      {0}", pd.DspType);
            Console.WriteLine("IsDacPresent {0:X}", pd.IsDacPresent);
            Console.WriteLine("Quartz       {0}", pd.Quartz);

            Console.WriteLine("Press any key");
            Console.ReadKey();

            uint bufferSize = 10000000;
            LCardApi.RequestBufferStream(ref bufferSize, LCardApi.L_STREAM_ADC);
            Console.WriteLine("Allocated memory size(word): {0}", bufferSize);

            WADC_PAR_0 adcPar = new WADC_PAR_0
            {
                s_Type = LCardApi.L_ADC_PARAM,
                AutoInit = 1,
                dRate = 100.0D,
                dKadr = 0,
                dScale = 0,
                SynchroType = 3,
                SynchroSensitivity = 0,
                SynchroMode = 0,
                AdChannel = 0,
                AdPorog = 0,
                NCh = 4
            };

            adcPar.Chn = new uint[128];
            adcPar.Chn[0] = 0x0;
            adcPar.Chn[1] = 0x1;
            adcPar.Chn[2] = 0x2;
            adcPar.Chn[3] = 0x3;
            adcPar.FIFO = 1024;
            adcPar.IrqStep = 1024;
            adcPar.Pages = 128;
            adcPar.IrqEna = 1;
            adcPar.AdcEna = 1;

            IntPtr Sync = new IntPtr();
            IntPtr Data = new IntPtr();

            LCardApi.FillDAQparameters(ref adcPar, LCardApi.CASE_ADC_PAR_0);
            LCardApi.SetParametersStream(ref adcPar, LCardApi.CASE_ADC_PAR_0, ref bufferSize, ref Data, ref Sync, LCardApi.L_STREAM_ADC);

            Console.WriteLine("Buffer size(points): {0}", bufferSize);
            Console.WriteLine("Pages:               {0}", adcPar.Pages);
            Console.WriteLine("IrqStep:             {0}", adcPar.IrqStep);
            Console.WriteLine("FIFO:                {0}", adcPar.FIFO);
            Console.WriteLine("Rate:                {0:F}", adcPar.dRate);
            Console.WriteLine("Kadr:                {0:F}", adcPar.dKadr);

            var IrqStep = adcPar.IrqStep;
            var pages = adcPar.Pages;

            Console.WriteLine("Press any key");
            Console.ReadKey();
            */
        }
    }
}
