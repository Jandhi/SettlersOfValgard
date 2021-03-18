using System;

namespace SettlersOfValgardGame.ui.console.text
{
    public class VTextWrapper<T> : VText
    {
        public VTextWrapper(T contents, Func<T, VText> transform)
        {
            Contents = contents;
            Transform = transform;
        }

        public T Contents { get; }
        public Func<T, VText> Transform { get; }
        public VText Text => Transform(Contents);
        
        public override VText Plus(VText other)
        {
            return Text.Plus(other);
        }

        public override VText Apply(VTextTransform transform)
        {
            return Text.Apply(transform);
        }

        public override string GetContentRaw()
        {
            return Text.GetContentRaw();
        }

        public override VText Copy()
        {
            return Text.Copy();
        }

        public override string MakeString()
        {
            return Text.MakeString();
        }
    }
}