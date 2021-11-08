using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCardLib
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
}
