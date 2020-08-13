using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.Model.Building.Workplace.Harvest;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.Model.Resource.Material;

namespace SettlersOfValgard.Model.Varsk.Tech
{
    public static class VarskBlueprints
    {
        public static readonly Blueprint Hut = new Blueprint("Hut", new Hut(), new Bundle(Material.Wood, 10));
        public static readonly Blueprint GatherersHut = new Blueprint("Gatherer's Hut", new GatherersHut(), new Bundle(Material.Wood, 10));
        public static readonly Blueprint WoodcuttersHut = new Blueprint("Woodcutter's Hut", new WoodcuttersHut(), new Bundle(Material.Wood, 10));
        public static readonly Blueprint HuntersHut = new Blueprint("Hunter's Hut", new HuntersHut(), new Bundle(Material.Wood, 10));
    }
}