using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.Model.Varsk
{
    public class VarskNameFactories
    {
        public readonly string[] Prefix =
        {
            "rag", "ragn", "ravn", "regn"
        };
        
        public readonly string[] MaleSuffix =
        {
            "ar",
            "mund"
        };
        
        public readonly string[] FemaleSuffix =
        {
            "a",
            "hild"
        };
        
        public NameFactory Male()
        {
            return new RandomPrefixSuffixFactory(Prefix, MaleSuffix);
        }
        
        public NameFactory Female()
        {
            return new RandomPrefixSuffixFactory(Prefix, FemaleSuffix);
        }
    }
}