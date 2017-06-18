using System;
using System.Runtime.InteropServices;

namespace Cafemoca.DeskBandSample.DeskBand
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6D5140C1-7436-11CE-8034-00AA006009FA")]
    public interface IServiceProvider
    {
        [PreserveSig]
        void QueryService(ref Guid guid, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object obj);
    }
}
