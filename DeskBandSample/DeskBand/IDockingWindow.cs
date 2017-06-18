using System;
using System.Runtime.InteropServices;

namespace Cafemoca.DeskBandSample.DeskBand
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("012dd920-7b26-11d0-8ca9-00a0c92dbfe8")]
    public interface IDockingWindow : IOleWindow
    {
        [PreserveSig]
        void ShowDW([In] bool fShow);

        [PreserveSig]
        void CloseDW([In] uint dwReserved);

        [PreserveSig]
        void ResizeBorderDW(IntPtr prcBorder, [In, MarshalAs(UnmanagedType.IUnknown)] object punkToolbarSite, bool fReserved);
    }
}
