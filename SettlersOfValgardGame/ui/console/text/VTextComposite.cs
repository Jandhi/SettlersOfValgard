using System.Collections.Generic;
using System.Linq;

namespace SettlersOfValgardGame.ui.console.text
{
    public class VTextComposite : VText
    {
        public VTextComposite(params VText[] segments)
        {
            Parts = new List<VText>(segments);
        }

        public List<VText> Parts { get; }
        
        public override string ToString()
        {
            return Parts.Aggregate("", (current, part) => current + part);
        }

        public override VText Add(VText other)
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
    }
}