using SettlersOfValgard.Model.Settler.Prestige;
using SettlersOfValgard.Model.Tech;

namespace SettlersOfValgard.Model.Culture
{
    public abstract class Culture
    {

        public abstract TechTree TechTree { get; }
        public abstract PrestigeSystem PrestigeSystem { get; }
    }
}