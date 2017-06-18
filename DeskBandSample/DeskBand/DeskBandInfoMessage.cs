using System;

namespace Cafemoca.DeskBandSample.DeskBand
{
    [Flags]
    public enum DeskBandInfoMessage : uint
    {
        NORMAL = 0,
        MINSIZE = 0x0001,
        MAXSIZE = 0x0002,
        INTEGRAL = 0x0004,
        ACTUAL = 0x0008,
        TITLE = 0x0010,
        MODEFLAGS = 0x0020,
        BKCOLOR = 0x0040,
        USECHEVRON = 0x0080,
        BREAK = 0x0100,
        ADDTOFRONT = 0x0200,
        TOPALIGN = 0x0400,

    }
}
