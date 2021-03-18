using SettlersOfValgardGame.settlersOfValgard.buildings.prototypes;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.buildings
{
    public abstract class Building : NamedObject
    {

        public abstract BuildingPrototype BuildingPrototype { get; }
        public override string NameText => BuildingPrototype.NameText;
        public override VColor NameForeground => BuildingPrototype.NameForeground;
    }
}