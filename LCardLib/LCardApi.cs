using System;
using System.Runtime.InteropServices;

namespace LCardLib
{
    

    

    public static class LCardApi
    {
        // ERROR CODES
        public const uint L_SUCCESS = 0;
        public const uint L_NOTSUPPORTED = 1;
        public const uint L_ERROR = 2;
        public const uint L_ERROR_NOBOARD = 3;
        public const uint L_ERROR_INUSE = 4;
        public const uint L_ERROR_TIMEOUT = 5;

        // define s_Type for FillDAQparameters
        public const int L_ADC_PARAM = 1;
        public const int L_DAC_PARAM = 2;

        public const int CASE_DAC_PAR_0 = 0;
        public const int CASE_DAC_PAR_1 = 1;
        public const int CASE_ADC_PAR_0 = 2;
        public const int CASE_ADC_PAR_1 = 3;

        public const int L_STREAM_NULL = 0;
        public const int L_STREAM_ADC = 1;
        public const int L_STREAM_DAC = 2;
        public const int L_STREAM_TTLIN = 3;
        public const int L_STREAM_TTLOUT = 4;
        public const int L_STREAM_FMETER = 5;
        public const int L_STREAM_DDS = 6;



#if WIN64
        const string WLCompDll = "wlcomp64.dll";
#else
        const string WLCompDll = "wlcomp.dll";
#endif

#if WIN64
        const string LCompDll = "lcomp64.dll";
#else
        const string LCompDll = "lcomp.dll";
#endif

        private static class WLCompStub
        {
            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr CallCreateInstance(ref ulong hDll, uint Slot, ref uint Err);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenLDevice(ref IntPtr hObj);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint CloseLDevice(ref IntPtr hObj);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint LoadBios(ref IntPtr hObj, string BiosName);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint IoAsync(ref IntPtr hObj, ref WASYNC_PAR sp);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint PlataTest(ref IntPtr hObj);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint ReadPlataDescr(ref IntPtr hObj, out PLATA_DESCR pd);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint StartLDevice(ref IntPtr hObj);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint RequestBufferStream(ref IntPtr hObj, ref uint UsedSize, uint StreamId);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint FillDAQparameters(ref IntPtr hObj, ref WADC_PAR_0 sp, uint sp_type);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint SetParametersStream(ref IntPtr hObj, ref WADC_PAR_0 sp, uint sp_type, ref uint UsedSize, ref IntPtr Data, ref IntPtr Sync, uint StreamId);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint GetSlotParam(ref IntPtr hObj, out SLOT_PARAM slPar);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint InitStartLDevice(ref IntPtr hObj);

            [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
            public static extern uint StopLDevice(ref IntPtr hObj);
        }

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ulong LoadAPIDLL(string dllname);

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern uint FreeAPIDLL(ref ulong hDll);

        

        private static ulong hDll;

        private static IntPtr hIfc = IntPtr.Zero;

        private static readonly Destructor Finalise = new Destructor();

        static LCardApi()
        {
            hDll = LoadAPIDLL(LCompDll);
        }

        public static bool OpenSlot(uint Slot, out uint Err)
        {
            Err = L_SUCCESS;
            hIfc = WLCompStub.CallCreateInstance(ref hDll, Slot, ref Err);
            return (hIfc != null);
        }

        public static bool OpenSlot(uint Slot)
        {
            return OpenSlot(Slot, out _);
        }

        public static IntPtr OpenLDevice()
        {
            return WLCompStub.OpenLDevice(ref hIfc);
        }

        public static uint CloseLDevice()
        {
            return WLCompStub.CloseLDevice(ref hIfc);
        }


        public static uint LoadBios(string BiosName)
        {
            return WLCompStub.LoadBios(ref hIfc, BiosName);
        }

        public static uint PlataTest()
        {
            return WLCompStub.PlataTest(ref hIfc);
        }

        public static uint GetSlotParam(out SLOT_PARAM slPar)
        {
            return WLCompStub.GetSlotParam(ref hIfc, out slPar);
        }

        public static uint ReadPlataDescr(out PLATA_DESCR pd)
        {
            return WLCompStub.ReadPlataDescr(ref hIfc, out pd);
        }

        public static uint RequestBufferStream(ref uint UsedSize, uint StreamId)
        {
            return WLCompStub.RequestBufferStream(ref hIfc, ref UsedSize, StreamId);
        }

        public static uint FillDAQparameters(ref WADC_PAR_0 sp, uint sp_type)
        {
            return WLCompStub.FillDAQparameters(ref hIfc, ref sp, sp_type);
        }

        public static uint SetParametersStream(ref WADC_PAR_0 sp, uint sp_type, ref uint UsedSize, ref IntPtr Data, ref IntPtr Sync, uint StreamId)
        {
            return WLCompStub.SetParametersStream(ref hIfc, ref sp, sp_type, ref UsedSize, ref Data, ref Sync, StreamId);
        }

        private sealed class Destructor
        {
            ~Destructor()
            {
                FreeAPIDLL(ref hDll);
            }
        }
    }
}
