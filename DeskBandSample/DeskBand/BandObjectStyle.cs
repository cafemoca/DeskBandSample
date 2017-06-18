using System;

namespace Cafemoca.DeskBandSample.DeskBand
{
    [Flags]
    [Serializable]
    public enum BandObjectStyle : uint
    {
        None = 0x00,
        Vertical = 0x01,
        Horizontal = 0x02,
        ExplorerToolbar = 0x04,
        TaskbarToolBar = 0x08,
    }
}
