using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;

namespace SettlersOfValgardGame.ui.models
{
    public abstract class NamedObject : GeneratedVText, INamed
    {

        public abstract string NameText { get; }
        public virtual VColor NameForeground => null;
        public virtual VColor NameBackground => null;
        public virtual VTextFeature[] NameFeatures => new VTextFeature[0];
        public VText Name => new VTextSegment(NameText, NameForeground, NameBackground, NameFeatures);
        public override VText ToVText()
        {
            return Name;
        }
    }
}