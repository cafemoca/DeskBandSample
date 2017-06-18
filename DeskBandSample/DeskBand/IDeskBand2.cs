using System;
using System.Runtime.InteropServices;

namespace Cafemoca.DeskBandSample.DeskBand
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("79D16DE4-ABEE-4021-8D9D-9169B261D657")]
    public interface IDeskBand2 : IDeskBand
    {
        [PreserveSig]
        void CanRenderComposited(out bool pfCanRenderComposited);

        [PreserveSig]
        void SetCompositionState(bool fCompositionEnabled);

        [PreserveSig]
        void GetCompositionState(out bool pfCompositionEnabled);
    }
}
