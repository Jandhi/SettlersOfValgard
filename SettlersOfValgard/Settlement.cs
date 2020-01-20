using System.Collections.Generic;
using SettlersOfValgard.building;

namespace SettlersOfValgard
{
    public class Settlement : Named
    {
        
        public string Name { get; }
        
        public List<Settler> Settlers = new List<Settler>();
        public List<Building> Buildings = new List<Building>();
    }
}