namespace SettlersOfValgardGame.ui.console.text
{
    public abstract class VText
    {
        public abstract VText Add(VText other);
        public abstract VText Apply(VTextTransform transform);
        
        public static VText operator +(VText v1, VText v2)
        {
            return v1.Add(v2);
        }
    }
}