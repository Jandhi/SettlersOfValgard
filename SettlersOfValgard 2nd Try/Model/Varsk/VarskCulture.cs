using SettlersOfValgard.Model.Settler.Prestige;
using SettlersOfValgard.Model.Tech;
using SettlersOfValgard.Model.Varsk.Tech;

namespace SettlersOfValgard.Model.Varsk
{
    public class VarskCulture : Culture.Culture
    {
        public override TechTree TechTree { get; } = new VarskTechTree();
        public override PrestigeSystem PrestigeSystem { get; } = new VarskPrestigeSystem();
    }
}