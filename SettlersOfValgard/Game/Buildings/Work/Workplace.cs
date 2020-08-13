using System.Collections.Generic;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Settlers;

namespace SettlersOfValgard.Game.Buildings.Work
{
    public abstract class Workplace : Building
    {
        protected Workplace(Region region, List<Settler> workers) : base(region)
        {
            Workers = workers;
        }

        public abstract void HostWork(Settler worker);
        public List<Settler> Workers { get; }
    }
}