using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Cafemoca.DeskBandSample.DeskBand;

namespace Cafemoca.DeskBandSample
{
    [Guid("6E26E58A-D2E1-4001-AB88-02CFE62CD668"), ComVisible(true)]
    [BandObject("DeskBandSample", BandObjectStyle.TaskbarToolBar)]
    public class DeskBandSample : BandObject
    {
        private Button _button;

        public DeskBandSample()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this._button = new Button();
            this.SuspendLayout();
            // 
            // button
            // 
            this._button.Location = new Point(0, 0);
            this._button.Name = "_button";
            this._button.Size = new Size(150, 20);
            this._button.TabIndex = 0;
            this._button.Text = "DeskBandSample";
            this._button.UseVisualStyleBackColor = true;
            // 
            // DeskBandSample
            // 
            this.Controls.Add(this._button);
            this.MinSize = new Size(150, 20);
            this.Name = "DeskBandSample";
            this.Size = new Size(150, 20);
            this.Title = "DeskBandSample";
            this.ResumeLayout(false);

        }
    }
}
