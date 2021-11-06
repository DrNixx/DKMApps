using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCardDiags
{
    class Program
    {
        static void Main(string[] args)
        {
            var hIfc = LCardApi.Init();

            var err = LCardApi.OpenLDevice(ref hIfc);
            Console.WriteLine("OpenLDevice Handle {0}", err);

            err = LCardApi.LoadBios(ref hIfc, "l761");
            Console.WriteLine("LoadBios Status: {0}", err);

            var Err = LCardApi.PlataTest(ref hIfc);

            Console.WriteLine("Plata test {0:X}", Err);

            Console.WriteLine("Slot parameters");

            SLOT_PARAM sl;
            LCardApi.GetSlotParam(ref hIfc, out sl);

            Console.WriteLine("Base    {0:X}", sl.Base);
            Console.WriteLine("BaseL   {0:X}", sl.BaseL);
            Console.WriteLine("Mem     {0:X}", sl.Mem);
            Console.WriteLine("MemL    {0:X}", sl.MemL);
            Console.WriteLine("Type    {0:X}", sl.BoardType);
            Console.WriteLine("DSPType {0:X}", sl.DSPType);
            Console.WriteLine("Irq     {0:X}", sl.Irq);

            Console.WriteLine("Press any key");
            Console.ReadKey();


            Console.ReadKey();
        }
    }
}
