using System;

namespace Cafemoca.DeskBandSample.DeskBand
{
    public class BandObjectAttribute : Attribute
    {
        public string Name { get; set; }
        public string HelpText { get; set; }
        public BandObjectStyle BandObjectStyle { get; set; }

        public BandObjectAttribute()
        {
        }

        public BandObjectAttribute(string name, BandObjectStyle style)
            : this(name, name, style)
        {
        }

        public BandObjectAttribute(string name, string helpText, BandObjectStyle style)
        {
            this.Name = name;
            this.HelpText = helpText;
            this.BandObjectStyle = style;
        }
    }
}
