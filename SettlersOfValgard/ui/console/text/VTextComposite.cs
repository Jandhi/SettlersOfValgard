using System.Collections.Generic;
using System.Linq;

namespace SettlersOfValgardGame.ui.console.text
{
    public class VTextComposite : VText
    {
        public VTextComposite(params string[] texts)
        {
            Parts = new List<VText>(texts.Select(text => new VTextSegment(text)));    
        }
        
        public VTextComposite(params VText[] segments)
        {
            Parts = new List<VText>(segments);
        }

        public List<VText> Parts { get; }

        public override string MakeString()
        {
            return Parts.Aggregate("", (current, part) => current + part);
        }

        public override VText Plus(VText other)
        {
            Parts.Add(other);
            return this;
        }

        public override VText Apply(VTextTransform transform)
        {
            foreach (var part in Parts)
            {
                part.Apply(transform);
            }

            return this;
        }

        public override string GetContentRaw()
        {
            var text = "";
            
            foreach (var part in Parts)
            {
                text += part.GetContentRaw();
            }

            return text;
        }

        public override VText Copy()
        {
            return new VTextComposite(Parts.ToArray());
        }
    }
}