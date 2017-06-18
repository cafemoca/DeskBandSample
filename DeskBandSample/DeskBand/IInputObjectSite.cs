using System;
using System.Runtime.InteropServices;

namespace Cafemoca.DeskBandSample.DeskBand
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F1DB8392-7331-11D0-8C99-00A0C92DBFE8")]
    public interface IInputObjectSite
    {
        [PreserveSig]
        int OnFocusChangeIS([MarshalAs(UnmanagedType.IUnknown)] object punkObj, int fSetFocus);
    }
}
