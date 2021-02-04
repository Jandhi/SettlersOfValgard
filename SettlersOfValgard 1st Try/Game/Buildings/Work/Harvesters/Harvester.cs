using System.Collections.Generic;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Regions.Features;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Settlers;

namespace SettlersOfValgard.Game.Buildings.Work.Harvesters
{
    public abstract class Harvester : Workplace
    {
        public Harvester(Region region, List<Settler> workers = null) : base(region, workers) {}
        public abstract Dictionary<Resource, int> Rates { get; }
        public abstract List<Feature> RequiredFeatures { get; }

        public override void HostWork(Settler worker, Game game)
        {
            foreach (var (resource, amount) in Rates)
            {
                game.Settlement.AddResource(resource, amount);
            }
        }
    }
}