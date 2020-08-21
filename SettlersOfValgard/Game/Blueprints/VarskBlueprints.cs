using System.Collections.Generic;
using SettlersOfValgard.Game.Buildings.Work.Harvesters;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Resources.Assets;
using SettlersOfValgard.Game.Resources.Material;

namespace SettlersOfValgard.Game.Blueprints
{
    public static class VarskBlueprints
    {
        public static readonly Blueprint WoodcuttersHutBlueprint = new Blueprint(
            new Dictionary<Resource, int> {{Asset.Labour, 20}, {Material.Wood, 10}}, new WoodcuttersHut(null));
        public static readonly Blueprint HuntersHutBlueprint = new Blueprint(
            new Dictionary<Resource, int>{{Asset.Labour, 20}, {Material.Wood, 10}}, new HuntersHut(null));
    }
}