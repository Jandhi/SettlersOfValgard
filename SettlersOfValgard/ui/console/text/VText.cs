using System.Linq;

namespace SettlersOfValgardGame.ui.console.text
{
    public abstract class VText
    {
        public abstract VText Plus(VText other);
        public abstract VText Apply(VTextTransform transform);

        public VText Apply(params VTextTransform[] transforms)
        {
            return transforms.Aggregate(this, (text, transform) => text.Apply(transform));
        }
        public abstract string GetContentRaw();
        public abstract VText Copy();
        public abstract string MakeString();

        public static VText operator +(VText v1, VText v2)
        {
            return v1.Plus(v2);
        }

        public override string ToString()
        {
            return MakeString();
        }
    }
}