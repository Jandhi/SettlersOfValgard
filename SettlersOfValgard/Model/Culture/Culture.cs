using SettlersOfValgard.Model.Tech;

namespace SettlersOfValgard.Model.Culture
{
    public class Culture
    {
        public Culture(TechTree techTree)
        {
            TechTree = techTree;
        }

        public TechTree TechTree { get; }
    }
}