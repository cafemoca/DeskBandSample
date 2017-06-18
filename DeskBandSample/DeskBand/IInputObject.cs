using System;
using System.Runtime.InteropServices;

namespace Cafemoca.DeskBandSample.DeskBand
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("68284faa-6a48-11d0-8c78-00c04fd918b4")]
    public interface IInputObject
    {
        void UIActivateIO(int fActivate, ref MSG msg);

        [PreserveSig]
        int HasFocusIO();

        [PreserveSig]
        int TranslateAcceleratorIO(ref MSG msg);
    }
}
