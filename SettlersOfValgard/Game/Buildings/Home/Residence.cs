using System.Collections.Generic;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Settlers;

namespace SettlersOfValgard.Game.Buildings.Home
{
    public abstract class Residence : Building
    {
        public abstract int Capacity { get; }
        public List<Settler> Residents { get; }
        
        protected Residence(Region region, List<Settler> residents = null) : base(region)
        {
            Residents = residents ?? new List<Settler>();
        }
    }
}