using System.Collections.Generic;
using SettlersOfValgard.Game.Blueprints;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Resources.Food;
using SettlersOfValgard.Game.Resources.Material;
using SettlersOfValgard.Game.Resources.Storage;
using SettlersOfValgard.Game.Settlers;
using SettlersOfValgard.Interface.Console;

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
                var limits = new Bundle(new Dictionary<Resource, int>
                {
                    {Material.Wood, 20},
                    {Food.Meat, 10}
                });
                var region = new Region("Region_1", VColor.Green,"", limits);
                return new List<Region>{region};
            }
        }

        public static List<Settler> TestSettlers
        {
            get
            {
                var list = new List<Settler>();
                for (var i = 0; i < 9; i++)
                {
                    if (i % 3 == 0)
                    {
                        list.Add(new Settler($"Settlers_{i + 1}", new Family()));
                    }
                    else
                    {
                        list.Add(new Settler($"Settler_{i + 1}", list[i - 1].Family));
                    }
                }

                return list;
            }
        }
    }
}