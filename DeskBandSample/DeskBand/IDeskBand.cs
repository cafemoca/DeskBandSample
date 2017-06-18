using System;
using System.Runtime.InteropServices;

namespace Cafemoca.DeskBandSample.DeskBand
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EB0FE172-1A3A-11D0-89B3-00A0C90A90AC")]
    public interface IDeskBand : IDockingWindow
    {
        [PreserveSig]
        void GetBandInfo([In] uint dwBandID, [In] uint dwViewMode, [In, Out] ref DeskBankInfo pdbi);
    }
}
