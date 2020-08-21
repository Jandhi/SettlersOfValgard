using System.Collections.Generic;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Resources.Food;
using SettlersOfValgard.Interface.Console;

namespace SettlersOfValgard.Game.Buildings.Work.Harvesters
{
    public class HuntersHut : Harvester
    {
        public override Dictionary<Resource, int> Rates => new Dictionary<Resource, int>{{Food.Meat, 2}};

        public HuntersHut(Region region) : base(region)
        {
        }

        public override string Name => "Hunter's Hut";
        public override string Description => "A hunter's outpost near a game trail.";
        public override VColor Color => VColor.Green;

        public override Building Build(Region region)
        {
            return new HuntersHut(region);
        }
    }
}