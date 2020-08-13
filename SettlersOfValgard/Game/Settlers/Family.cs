using System.Collections.Generic;
using SettlersOfValgard.Game.Buildings.Home;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Settlers
{
    public class Family : INamed
    {
        public string Name { get; }
        public List<Settler> Members { get; } = new List<Settler>();
        public Residence Home { get; set; }
    }
}