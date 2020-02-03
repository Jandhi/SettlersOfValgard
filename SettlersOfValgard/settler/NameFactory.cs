namespace SettlersOfValgard.settler
{
    public abstract class NameFactory
    {
        public abstract string GetSettlerName(Gender gender, int years);
    }

    public class VarskNameFactory : NameFactory
    {
        public static string[] Prefix =
        {
            "Ag", "Alv", "As",
            "Gunn",
            "Ragn"
        };

        public static string[] MaleSuffix =
        {
            "ar",
            "i",
            "mund"
        };

        public static string[] FemaleSuffix =
        {
            "a",
            "frid",
            "hild"
        };

        public override string GetSettlerName(Gender gender, int years)
        {
            switch (gender)
            {
                case Gender.Male:
                    return Random.Entry(Prefix) + Random.Entry(MaleSuffix);
                case Gender.Female:
                    return Random.Entry(Prefix) + Random.Entry(FemaleSuffix);
                default:
                    return Random.Entry(Prefix) + Random.Entry(Random.Odds(1, 2) ? MaleSuffix : FemaleSuffix);
            }
        }
    }
}