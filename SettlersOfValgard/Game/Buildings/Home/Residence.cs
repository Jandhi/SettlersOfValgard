using System.Collections.Generic;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Settlers;

namespace SettlersOfValgard.Game.Buildings.Home
{
    public abstract class Residence : Building
    {
        public abstract int Capacity { get; }
        public List<Family> Families { get; }
        
        protected Residence(Region region, List<Family> families = null) : base(region)
        {
            Families = families ?? new List<Family>();
        }
    }
}