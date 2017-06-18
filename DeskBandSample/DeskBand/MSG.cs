using System;
using System.Drawing;

namespace Cafemoca.DeskBandSample.DeskBand
{
    public struct MSG
    {
        public IntPtr hwnd;
        public uint message;
        public uint wParam;
        public int lParam;
        public uint time;
        public Point pt;
    }
}
