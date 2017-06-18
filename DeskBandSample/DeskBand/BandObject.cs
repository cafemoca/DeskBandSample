using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Cafemoca.DeskBandSample.DeskBand
{
    public class BandObject : UserControl, IDeskBand2, IObjectWithSite, IInputObject
    {
        protected WebBrowser Explorer;
        protected IInputObjectSite BandObjectSite;

        public event EventHandler ExplorerAttached;

        protected virtual void OnExplorerAttached()
        {
            this.ExplorerAttached?.Invoke(this, EventArgs.Empty);
        }

        [Browsable(true)]
        [DefaultValue("")]
        public string Title { get; set; } = "";

        [Browsable(true)]
        [DefaultValue(typeof(Size), "-1,-1")]
        public Size MinSize { get; set; } = new Size(-1, -1);

        [Browsable(true)]
        [DefaultValue(typeof(Size), "-1,-1")]
        public Size MaxSize { get; set; } = new Size(-1, -1);

        [Browsable(true)]
        [DefaultValue(typeof(Size), "-1,-1")]
        public Size IntegralSize { get; set; } = new Size(-1, -1);

        public virtual void GetWindow(out IntPtr phwnd)
        {
            this.CreateControl();
            phwnd = this.Handle;
        }

        public virtual void ContextSensitiveHelp(bool fEnterMode)
        {
        }

        public virtual void ShowDW(bool fShow)
        {
            if (fShow)
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
        }

        public virtual void CloseDW(uint dwReserved)
        {
            this.Dispose(true);
        }

        public virtual void ResizeBorderDW(IntPtr prcBorder, object punkToolbarSite, bool fReserved)
        {
        }

        public virtual void GetBandInfo(uint dwBandID, uint dwViewMode, ref DeskBankInfo pdbi)
        {
            pdbi.wszTitle = this.Title;

            pdbi.ptActual.X = this.Size.Width;
            pdbi.ptActual.Y = this.Size.Height;

            pdbi.ptMaxSize.X = this.MaxSize.Width;
            pdbi.ptMaxSize.Y = this.MaxSize.Height;

            pdbi.ptMinSize.X = this.MinSize.Width;
            pdbi.ptMinSize.Y = this.MinSize.Height;

            pdbi.ptIntegral.X = this.IntegralSize.Width;
            pdbi.ptIntegral.Y = this.IntegralSize.Height;

            pdbi.dwModeFlags = DeskBandInfoMessage.TITLE | DeskBandInfoMessage.ACTUAL | DeskBandInfoMessage.MAXSIZE | DeskBandInfoMessage.MINSIZE | DeskBandInfoMessage.INTEGRAL;
        }

        public void CanRenderComposited(out bool pfCanRenderComposited)
        {
            pfCanRenderComposited = true;
        }

        public void SetCompositionState(bool fCompositionEnabled)
        {
        }

        public void GetCompositionState(out bool pfCompositionEnabled)
        {
            pfCompositionEnabled = true;
        }


        public virtual void UIActivateIO(int fActivate, ref MSG msg)
        {
            if (fActivate == 0)
            {
                return;
            }
            var control = this.GetNextControl(this, true);
            if (ModifierKeys == Keys.Shift)
            {
                control = this.GetNextControl(control, false);
            }
            control?.Select();
            this.Focus();
        }

        public virtual int HasFocusIO()
        {
            return this.ContainsFocus ? 0 : 1;
        }

        public virtual int TranslateAcceleratorIO(ref MSG msg)
        {
            if (msg.message != 0x100) return 1;
            if (msg.wParam != (uint) Keys.Tab && msg.wParam != (uint) Keys.F6) return 1;
            return this.SelectNextControl(this.ActiveControl, ModifierKeys != Keys.Shift, true, true, false) ? 0 : 1;
        }

        public virtual void SetSite(object pUnkSite)
        {
            if (this.BandObjectSite != null)
            {
                Marshal.ReleaseComObject(this.BandObjectSite);
            }
            if (this.Explorer != null)
            {
                Marshal.ReleaseComObject(this.Explorer);
                this.Explorer = null;
            }
            this.BandObjectSite = (IInputObjectSite)pUnkSite;
            if (this.BandObjectSite != null)
            {
                this.QueryExplorerWindow();
            }
        }

        private void QueryExplorerWindow()
        {
            var provider = this.BandObjectSite as IServiceProvider;

            var guid = new Guid("0002DF05-0000-0000-C000-000000000046");
            var riid = new Guid("00000000-0000-0000-C000-000000000046");

            try
            {
                object w;
                provider.QueryService(ref guid, ref riid, out w);

                this.Explorer = (WebBrowser)Marshal.CreateWrapperOfType(w as WebBrowser, typeof(WebBrowser));
                this.OnExplorerAttached();
            }
            catch
            {
            }
        }

        public virtual void GetSite(ref Guid riid, out object ppvSite)
        {
            ppvSite = this.BandObjectSite;
        }

        [ComRegisterFunction]
        public static void Register(Type type)
        {
            var guid = type.GUID.ToString("B");

            var rkClass = Registry.ClassesRoot.CreateSubKey($@"CLSID\{guid}");
            var rkCategory = rkClass.CreateSubKey("Implemented Categories");

            var attribute = (BandObjectAttribute[])type.GetCustomAttributes(typeof(BandObjectAttribute), false);

            var name = type.Name;
            var help = type.Name;
            var style = BandObjectStyle.None;

            if (attribute.Length == 1)
            {
                if (attribute[0].Name != null)
                {
                    name = attribute[0].Name;
                }
                if (attribute[0].HelpText != null)
                {
                    help = attribute[0].HelpText;
                }
                style = attribute[0].BandObjectStyle;
            }

            rkClass.SetValue(null, name);
            rkClass.SetValue("MenuText", name);
            rkClass.SetValue("HelpText", help);

            if ((style & BandObjectStyle.Vertical) != 0)
            {
                rkCategory.CreateSubKey("{00021493-0000-0000-C000-000000000046}");
            }
            if ((style & BandObjectStyle.Horizontal) != 0)
            {
                rkCategory.CreateSubKey("{00021494-0000-0000-C000-000000000046}");
            }
            if ((style & BandObjectStyle.ExplorerToolbar) != 0)
            {
                Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Toolbar").SetValue(guid, name);
            }
            if ((style & BandObjectStyle.TaskbarToolBar) != 0)
            {
                rkCategory.CreateSubKey("{00021492-0000-0000-C000-000000000046}");
            }
        }

        [ComUnregisterFunction]
        public static void Unregister(Type type)
        {
            var guid = type.GUID.ToString("B");
            var attributes = (BandObjectAttribute[])type.GetCustomAttributes(typeof(BandObjectAttribute), false);
            var style = BandObjectStyle.None;

            if (attributes.Length == 1)
            {
                style = attributes[0].BandObjectStyle;
            }

            if ((style & BandObjectStyle.ExplorerToolbar) != 0)
            {
                Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Toolbar").DeleteValue(guid, false);
            }

            Registry.ClassesRoot.CreateSubKey(@"CLSID").DeleteSubKeyTree(guid);
        }
    }
}
