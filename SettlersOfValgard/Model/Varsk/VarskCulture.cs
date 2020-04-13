using SettlersOfValgard.Model.Tech;
using SettlersOfValgard.Model.Varsk.Tech;

namespace SettlersOfValgard.Model.Varsk
{
    public class VarskCulture : Culture.Culture
    {
        public VarskCulture() : base(new VarskTechTree())
        {
        }
    }
}