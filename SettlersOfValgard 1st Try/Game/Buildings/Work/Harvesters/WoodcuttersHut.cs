using System.Collections.Generic;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Regions.Features;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Resources.Material;
using SettlersOfValgard.Game.Settlers;
using SettlersOfValgard.Interface.Console;

namespace SettlersOfValgard.Game.Buildings.Work.Harvesters
{
    public class WoodcuttersHut : Harvester
    {
        public WoodcuttersHut(Region region, List<Settler> workers = null) : base(region, workers)
        {
        }

        public override string Name => "Woodcutter's Hut";
        public override string Description => "A ";
        public override VColor Color => VColor.Green;
        public override Building Build(Region region)
        {
            return new WoodcuttersHut(region);
        }

        public override Dictionary<Resource, int> Rates => new Dictionary<Resource, int>{{Material.Wood, 1}};
        public override List<Feature> RequiredFeatures => new List<Feature>{Feature.Forest};
    }
}