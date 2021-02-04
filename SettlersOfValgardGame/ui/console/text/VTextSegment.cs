using System.Collections.Generic;
using SettlersOfValgardGame.ui.console.color;

namespace SettlersOfValgardGame.ui.console.text
{
    public class VTextSegment : VText
    {
        public VTextSegment(string text, VColor foregroundColor = null, VColor backgroundColor = null, List<VTextFeature> features = null)
        {
            Text = text;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            Features = features ?? new List<VTextFeature>();
        }

        public const string ResetAnsi = "\u001b[0m";
        public string Text { get; }
        public VColor ForegroundColor { get; set; }
        public VColor BackgroundColor { get; set; }
        public List<VTextFeature> Features { get; set; }

        public override string ToString()
        {
            var fullText = "";
            
            if (ForegroundColor != null)
            {
                fullText += ForegroundColor.GetForegroundAnsi();
            }

            if (BackgroundColor != null)
            {
                fullText += BackgroundColor.GetBackgroundAnsi();
            }
            
            foreach (var feature in Features)
            {
                fullText += feature.Ansi;
            }

            fullText += Text;
            fullText += ResetAnsi;

            return fullText;
        }

        public override VText Add(VText other)
        {
            return new VTextComposite(this, other);
        }

        public override VText Apply(VTextTransform transform)
        {
            transform.DoTransform(this);
            return this;
        }
    }
}