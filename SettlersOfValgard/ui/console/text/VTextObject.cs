using SettlersOfValgardGame.ui.console.color;

namespace SettlersOfValgardGame.ui.console.text
{
    public abstract class VTextObject : VText
    {
        public abstract string Text { get; }
        public virtual VColor ForegroundColor => null;
        public virtual VColor BackgroundColor => null;

        public virtual VTextFeature[] Features => new VTextFeature[0];

        public VTextSegment ToTextSegment()
        {
            return new VTextSegment(Text, ForegroundColor, BackgroundColor, Features);
        }

        public override string MakeString()
        {
            return ToTextSegment().ToString();
        }

        public override VText Plus(VText other)
        {
            return new VTextComposite(ToTextSegment(), other);
        }

        public override VText Apply(VTextTransform transform)
        {
            return ToTextSegment().Apply(transform);
        }

        public override string GetContentRaw()
        {
            return Text;
        }

        public override VText Copy()
        {
            return ToTextSegment();
        }
    }
}