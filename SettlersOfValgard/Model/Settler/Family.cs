using System.Collections.Generic;
using SettlersOfValgard.Model.Building.Residence;

namespace SettlersOfValgard.Model.Settler
{
    public class Family
    {
        public List<Settler> Members { get; } = new List<Settler>();
        public Residence Home { get; set; }
    }
}