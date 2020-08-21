using System.Collections.Generic;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Settlers;

namespace SettlersOfValgard.Game.Buildings.Work
{
    public abstract class Workplace : Building
    {
        protected Workplace(Region region, List<Settler> workers = null) : base(region)
        {
            Workers = workers ?? new List<Settler>();
        }

        public abstract void HostWork(Settler worker, Game game);
        public List<Settler> Workers { get; }
    }
}