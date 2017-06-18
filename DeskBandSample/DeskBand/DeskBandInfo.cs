using System.Drawing;
using System.Runtime.InteropServices;

namespace Cafemoca.DeskBandSample.DeskBand
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DeskBankInfo
    {
        public uint dwMask;
        public Point ptMinSize;
        public Point ptMaxSize;
        public Point ptIntegral;
        public Point ptActual;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string wszTitle;
        public DeskBandInfoMessage dwModeFlags;
        public int crBkgnd;
    }
}
