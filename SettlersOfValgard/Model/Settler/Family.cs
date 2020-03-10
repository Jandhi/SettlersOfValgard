using System.Collections.Generic;
using SettlersOfValgard.Model.Building.Residence;

namespace SettlersOfValgard.Model.Settler
{
    public class Family
    {
        public List<Settler> Members { get; set; }
        public Residence Home { get; set; }
    }
}