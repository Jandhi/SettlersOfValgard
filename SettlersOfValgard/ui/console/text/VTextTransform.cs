using System;
using System.Collections.Generic;
using System.Text;
using SettlersOfValgardGame.ui.console.color;

namespace SettlersOfValgardGame.ui.console.text
{
    public class VTextTransform
    {
        public static VTextTransform SetForeground(VColor color, bool soft = false)
        {
            return new VTextTransform(segment =>
            {
                if(!soft || segment.ForegroundColor == null) {
                    segment.ForegroundColor = color;
                }
            });
        }
        
        public static VTextTransform SetBackground(VColor color, bool soft = false)
        {
            return new VTextTransform(segment =>
            {
                if(!soft || segment.BackgroundColor == null) {
                    segment.BackgroundColor = color;
                }
            });
        }
        
        public static VTextTransform AddFeatures(params VTextFeature[] features)
        {
            return new VTextTransform(segment =>
            {
                foreach (var feature in features)
                {
                    if(!segment.Features.Contains(feature)) {
                        segment.Features.Add(feature);
                    }
                }
            });
        }
        
        public static VTextTransform SetFeatures(params VTextFeature[] feature)
        {
            return new VTextTransform(segment =>
            {
                segment.Features = new List<VTextFeature>(feature);
            });
        }

        public static VTextTransform Quote()
        {
            return new VTextTransform(segment => { segment.Text = "\"" + segment.Text + "\""; });
        }
        
        public static VTextTransform Quote(string open, string close)
        {
            return new VTextTransform(segment => { segment.Text = open + segment.Text + close; });
        }

        public static VTextTransform ToUpper()
        {
            return new VTextTransform(segment => { segment.Text = segment.Text.ToUpper(); });
        }
        
        public static VTextTransform ToLower()
        {
            return new VTextTransform(segment => { segment.Text = segment.Text.ToLower(); });
        }
        
        public static VTextTransform ToMoCkErY()
        {
            return new VTextTransform(segment =>
            {
                var sb = new StringBuilder();
                for (var i = 0; i < segment.Text.Length; i++)
                {
                    var letter = segment.Text.Substring(i, 1);
                    sb.Append(i % 2 == 0 ? letter.ToUpper() : letter.ToLower());
                }

                segment.Text = sb.ToString();
            });
        }

        public static VTextTransform Capitalize()
        {
            return new VTextTransform(segment =>
                {
                    segment.Text = segment.Text.Substring(0, 1).ToUpper() + segment.Text.Substring(1);
                });
        }

        public static VTextTransform QuoteInput()
        {
            return new VTextTransform(segment =>
            {
                segment.Apply(Quote(), SetForeground(ColorStandards.Input));
            });
        }
        
        protected VTextTransform(Action<VTextSegment> doTransform)
        {
            DoTransform = doTransform;
        }

        public VText ApplyTo(VText text)
        {
            return text.Apply(this);
        }

        public Action<VTextSegment> DoTransform { get; }
    }
}