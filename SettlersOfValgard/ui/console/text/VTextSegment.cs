using System.Collections.Generic;
using SettlersOfValgardGame.ui.console.color;

namespace SettlersOfValgardGame.ui.console.text
{
    public class VTextSegment : VText
    {
        public VTextSegment(string text, VColor foregroundColor = null, VColor backgroundColor = null, params VTextFeature[] features)
        {
            Text = text;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            Features = new List<VTextFeature>(features);
        }

        public const string ResetAnsi = "\u001b[0m";
        public string Text { get; set; }
        public VColor ForegroundColor { get; set; }
        public VColor BackgroundColor { get; set; }
        public List<VTextFeature> Features { get; set; }

        public override string MakeString()
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

        public override VText Plus(VText other)
        {
            return new VTextComposite(Copy(), other);
        }

        public override VText Apply(VTextTransform transform)
        {
            transform.DoTransform(this);
            return this;
        }

        public override string GetContentRaw()
        {
            return Text;
        }

        public override VText Copy()
        {
            return new VTextSegment(Text, ForegroundColor, BackgroundColor, Features.ToArray());
        }
    }
}