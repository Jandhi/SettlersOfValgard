using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.Model.Varsk
{
    public class VarskNameFactories
    {
        public static readonly string[] Prefix =
        {
            "Alf", "Arn", "As",
            "Berg", "Bloth",
            "Eld",
            "Fast",
            "Gis", "Guth",
            "Hall", "Heim", "Holm",
            "Katl",
            "Magn",
            "Odd", "Oy",
            "Rag", "Ragn", "Ravn", "Regn",
            "Skjald", "Sig",
            "Thjoth", "Thor",
            "Veig",
            "Yng"
        };
        
        public static readonly string[] MaleSuffix =
        {
            "ar", "ald",
            "bjorn",
            "finn", "froed",
            "geirr",
            "kaell",
            "i",
            "leif",
            "marr", "mothr", "mund",
            "r", "rid", "rik",
            "ulf",
            "vald"
        };
        
        public static readonly string[] FemaleSuffix =
        {
            "a", "ja",
            "bjorg", "borg",
            "dis",
            "frid",
            "hild",
            "laug",
            "mod",
            "mod",
            "ny",
            "unn",
            "vild",
            "vi"
        };
        
        public static NameFactory Male()
        {
            return new RandomPrefixSuffixFactory(Prefix, MaleSuffix);
        }
        
        public static NameFactory Female()
        {
            return new RandomPrefixSuffixFactory(Prefix, FemaleSuffix);
        }
    }
}