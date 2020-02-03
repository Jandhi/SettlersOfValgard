using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.building;

namespace SettlersOfValgard.tech
{
    public class TechManager
    {
        public List<Tech> Techs = new List<Tech>();
        public List<Building> UnlockedBuildings = new List<Building>();

        public Building StringToUnlockedBuilding(string name)
        {
            return UnlockedBuildings.FirstOrDefault(building => building.Name == name);
        }

        public void Discover(Tech tech)
        {
            tech.GetDiscovered(this);
        }
    }
    
    public abstract class Tech
    {
        public abstract void GetDiscovered(TechManager manager);
    }
}