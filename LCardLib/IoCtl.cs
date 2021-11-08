using System.Runtime.InteropServices;

namespace LCardLib
{
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
}
