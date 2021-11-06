using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LCardDiags
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct PLATA_DESCR
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string SerNum;
        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BrdName;

        public byte Rev;
        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string DspType;
        
        public ulong Quartz;
        
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
    public struct ADC_PAR_0
    {
        public ulong AutoInit;
        
        public double dRate;
        
        public double dKadr;
        
        public double dScale;
        
        public ulong Rate;
        
        public ulong Kadr;
        
        public ulong Scale;
        
        public ulong FPDelay;
        
        public ulong SynchroType;
        
        public ulong SynchroSensitivity;
        
        public ulong SynchroMode;
        
        public ulong AdChannel;
        
        public ulong AdPorog;
        
        public ulong NCh;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public ulong[] Chn;
        
        public ulong IrqEna;
        
        public ulong AdcEna;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SLOT_PARAM
    {
        public ulong Base;
        
        public ulong BaseL;
        
        public ulong Base1;
        
        public ulong BaseL1;
        
        public ulong Mem;
        
        public ulong MemL;
        
        public ulong Mem1;
        
        public ulong MemL1;
        
        public ulong Irq;
        
        public ulong BoardType;
        
        public ulong DSPType;
        
        public ulong Dma;
        
        public ulong DmaDac;
        
        public ulong DTA_REG;
        
        public ulong IDMA_REG;
        
        public ulong CMD_REG;
        
        public ulong IRQ_RST;
        
        public ulong DTA_ARRAY;
        
        public ulong RDY_REG;
        
        public ulong CFG_REG;
    }


    public struct WASYNC_PAR
    {
        public ulong s_Type;
        
        public ulong FIFO;
        
        public ulong IrqStep;
        
        public ulong Pages;
        
        public double dRate;
        
        public ulong Rate;
        
        public ulong NCh;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public ulong[] Chn;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]        
        public ulong[] Data;

        public ulong Mode;
    }

    public static class LCardApi
    {
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
        public static extern uint LoadAPIDLL(string dllname);

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FreeAPIDLL(ref uint hDll);

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint CallCreateInstance(ref uint hDll, uint Slot, ref uint Err);

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint OpenLDevice(ref uint hObj);
        
        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint CloseLDevice(ref uint hObj);
        
        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint LoadBios(ref uint hObj, string BiosName);

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint IoAsync(ref uint hObj, ref WASYNC_PAR sp);

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint PlataTest(ref uint hObj);
        
        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ReadPlataDescr(ref uint hObj, ref PLATA_DESCR pd);
        
        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint StartLDevice(ref uint hObj);

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint RequestBufferStream(ref uint hObj, ref uint UsedSize, uint StreamId);
        
        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint FillDAQparameters(ref uint hObj, ref ADC_PAR_0 sp, uint sp_type);
        
        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SetParametersStream(ref uint hObj, ref ADC_PAR_0 sp, uint sp_type, ref uint UsedSize, ref IntPtr Data, ref IntPtr Sync, uint StreamId);

        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetSlotParam(ref uint hObj, out SLOT_PARAM slPar);
        
        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint InitStartLDevice(ref uint hObj);
        
        [DllImport(WLCompDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint StopLDevice(ref uint hObj);

        public static uint Init()
        {
            uint hDll;
            uint Err = 0;

            string s = LCompDll;
            hDll = LoadAPIDLL(s);
            return CallCreateInstance(ref hDll, 0, ref Err);
        }
    }
}
