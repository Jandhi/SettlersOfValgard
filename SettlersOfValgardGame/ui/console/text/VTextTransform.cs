using System;
using System.Collections.Generic;
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
        
        protected VTextTransform(Action<VTextSegment> doTransform)
        {
            DoTransform = doTransform;
        }

        public Action<VTextSegment> DoTransform { get; }
    }
}