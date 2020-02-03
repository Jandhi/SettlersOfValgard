using SettlersOfValgard.building.harvest;
using SettlersOfValgard.building.Residential;

namespace SettlersOfValgard.tech
{
    public class BasicTech : Tech
    {
        public override void GetDiscovered(TechManager manager)
        {
            manager.UnlockedBuildings.Add(new Tent());
            manager.UnlockedBuildings.Add(new HuntersHut());
        }
    }
}