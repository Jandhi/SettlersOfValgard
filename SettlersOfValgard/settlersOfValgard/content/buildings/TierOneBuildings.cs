using SettlersOfValgardGame.settlersOfValgard.buildings.blueprint;
using SettlersOfValgardGame.settlersOfValgard.buildings.prototypes;
using SettlersOfValgardGame.settlersOfValgard.resources;
using SettlersOfValgardGame.settlersOfValgard.resources.bundles;
using SettlersOfValgardGame.ui.console.color;

namespace SettlersOfValgardGame.settlersOfValgard.content.buildings
{
    public static class TierOneBuildings
    {
        public static ResidencePrototype Hut = new ResidencePrototype("Hut", VColor.Grass, 1);
        public static Blueprint HutBlueprint = new Blueprint("Hut", Hut, new Bundle((Material.Wood, 2)));
    }
}