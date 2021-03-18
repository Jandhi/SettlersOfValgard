using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;

namespace SettlersOfValgardGame.ui.models
{
    public abstract class NamedObject : VText, INamed
    {

        public abstract string NameText { get; }
        public virtual VColor NameForeground => null;
        public virtual VColor NameBackground => null;
        public virtual VTextFeature[] NameFeatures => new VTextFeature[0];
        public VText Name => new VTextSegment(NameText, NameForeground, NameBackground, NameFeatures);

        public override VText Plus(VText other)
        {
            return Name.Plus(other);
        }

        public override string MakeString()
        {
            return Name.MakeString();
        }

        public override VText Apply(VTextTransform transform)
        {
            return Name.Apply(transform);
        }

        public override string GetContentRaw()
        {
            return Name.GetContentRaw();
        }

        public override VText Copy()
        {
            return Name.Copy();
        }
    }
}