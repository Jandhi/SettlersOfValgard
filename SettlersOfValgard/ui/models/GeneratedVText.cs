using SettlersOfValgardGame.ui.console.text;

namespace SettlersOfValgardGame.ui.models
{
    //For classes that can be turned into VText
    public abstract class GeneratedVText : VText
    {
        public abstract VText ToVText();
        
        public override VText Plus(VText other)
        {
            return ToVText().Plus(other);
        }

        public override VText Apply(VTextTransform transform)
        {
            return ToVText().Apply(transform);
        }

        public override string GetContentRaw()
        {
            return ToVText().GetContentRaw();
        }

        public override VText Copy()
        {
            return ToVText().Copy();
        }

        public override string MakeString()
        {
            return ToVText().MakeString();
        }
    }
}