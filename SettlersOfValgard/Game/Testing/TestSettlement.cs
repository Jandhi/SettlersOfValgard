using System.Collections.Generic;
using SettlersOfValgard.Game.Blueprints;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Regions.Features;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Resources.Food;
using SettlersOfValgard.Game.Resources.Material;
using SettlersOfValgard.Game.Resources.Storage;
using SettlersOfValgard.Game.Settlers;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Testing
{
    public class TestSettlement : Settlement
    {
        public TestSettlement() : base("Test", TestSettlers, TestRegions, new Stockpile(100), TestBlueprints)
        {
        }

        public static List<Blueprint> TestBlueprints => new List<Blueprint>{VarskBlueprints.HuntersHutBlueprint, VarskBlueprints.WoodcuttersHutBlueprint};

        public static List<Region> TestRegions
        {
            get
            {
                var features = new List<Feature>{Feature.Forest, Feature.Forest, Feature.Forest, Feature.Plain, Feature.Plain};
                var region = new Region("Region_1", VColor.Green,"", features);
                return new List<Region>{region};
            }
        }

        public static List<Settler> TestSettlers
        {
            get
            {
                var list = new List<Settler>();
                var i = 1;
                ActionUtility.Repeat(() =>
                {
                    list.Add(new Settler($"settler_{i}"));
                    i++;
                }, 9);
                return list;
            }
        }
    }
}