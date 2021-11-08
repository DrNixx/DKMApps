using System;
using System.Runtime.InteropServices;

namespace LCardsLib
{
    public enum BoardTypes : uint
    {
        NONE = 0, // no board in slot
        L1250 = 1, // L1250 board
        N1250 = 2, // N1250 board (may be not work)
        L1251 = 3, // L1251 board
        L1221 = 4, // L1221 board
        PCIA = 5, // PCI rev A board
        PCIB = 6, // PCI rev B board
        L264 = 8, // L264 ISA board
        L305 = 9, // L305 ISA board
        L1450C = 10,
        L1450 = 11,
        L032 = 12,
        HI8 = 13,
        PCIC = 14,

        LYNX2 = 15,
        TIGER2 = 16,
        TIGER3 = 17,
        LION = 18,

        L791 = 19,
        LCPI = 20, // pci lcpi

        E440 = 30,
        E140 = 31,
        E2010 = 32,
        E270 = 33,
        CAN_USB = 34,
        AK9 = 35,
        LTR010 = 36,
        LTR021 = 37,
        E154 = 38,
        E2010B = 39,
        LTR031 = 40,
        LTR030 = 41,

        E310 = 77
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PLATA_DESCR
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string SerNum;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BrdName;

        public char Rev;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string DspType;

        public uint Quartz;

        public ushort IsDacPresent;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public ushort[] Reserv1;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public ushort[] KoefADC;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] KoefDAC;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public ushort[] Custom;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SLOT_PARAM
    {
        public uint Base;

        public uint BaseL;

        public uint Base1;

        public uint BaseL1;

        public uint Mem;

        public uint MemL;

        public uint Mem1;

        public uint MemL1;

        public uint Irq;

        public uint BoardType;

        public uint DSPType;

        public uint Dma;

        public uint DmaDac;

        public uint DTA_REG;

        public uint IDMA_REG;

        public uint CMD_REG;

        public uint IRQ_RST;

        public uint DTA_ARRAY;

        public uint RDY_REG;

        public uint CFG_REG;
    }


    public struct WASYNC_PAR
    {
        public uint s_Type;

        public uint FIFO;

        public uint IrqStep;

        public uint Pages;

        public uint dRate;

        public uint Rate;

        public uint NCh;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public uint[] Chn;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public uint[] Data;

        public uint Mode;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WADC_PAR_0
    {
        public uint s_Type;
        public uint FIFO;
        public uint IrqStep;
        public uint Pages;

        public uint AutoInit;

        public double dRate;
        public double dKadr;
        public double dScale;
        public uint Rate;
        public uint Kadr;
        public uint Scale;
        public uint FPDelay;

        public uint SynchroType;
        public uint SynchroSensitivity;
        public uint SynchroMode;
        public uint AdChannel;
        public uint AdPorog;
        public uint NCh;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public uint[] Chn;

        public uint IrqEna;

        public uint AdcEna;
    }

    public static class LCardApi
    {
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

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong LoadAPIDLL(string dllname);

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FreeAPIDLL(ref ulong hDll);

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CallCreateInstance(ref ulong hDll, uint Slot, ref uint Err);

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint OpenLDevice(ref IntPtr hObj);

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

        public static IntPtr Init()
        {
            ulong hDll;
            uint Err = 0;

            string s = LCompDll;
            hDll = LoadAPIDLL(s);
            return CallCreateInstance(ref hDll, 0, ref Err);
        }
    }
}
