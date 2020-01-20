using SettlersOfValgard.building;

namespace SettlersOfValgard
{
    public class Settler : Named
    {
        public string Name { get; }
        public int Age { get; }
        
        public WorkBuilding Work { get; set; }
        public ResidentialBuilding Home { get; set; }

        public Settler(string name)
        {
            Name = name;
        }
    }
}