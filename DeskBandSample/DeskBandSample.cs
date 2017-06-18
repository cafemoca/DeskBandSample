using System.Drawing;
using System.Runtime.InteropServices;
using Cafemoca.DeskBandSample.DeskBand;

namespace Cafemoca.DeskBandSample
{
    [Guid("6E26E58A-D2E1-4001-AB88-02CFE62CD668"), ComVisible(true)]
    [BandObject("SampleBand", BandObjectStyle.TaskbarToolBar)]
    public class SampleBand : BandObject
    {
        private System.Windows.Forms.Button button;

        public SampleBand()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new Point(0, 0);
            this.button.Name = "button";
            this.button.Size = new Size(150, 20);
            this.button.TabIndex = 0;
            this.button.Text = "DeskBandSample";
            this.button.UseVisualStyleBackColor = true;
            // 
            // SampleBand
            // 
            this.Controls.Add(this.button);
            this.MinSize = new Size(150, 20);
            this.Name = "SampleBand";
            this.Size = new Size(150, 20);
            this.Title = "DeskBandSample";
            this.ResumeLayout(false);

        }
    }
}
