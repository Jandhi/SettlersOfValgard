using SettlersOfValgardGame.settlersOfValgard.buildings.prototypes;
using SettlersOfValgardGame.settlersOfValgard.resources.storage;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.buildings.blueprint
{
    public class Blueprint : NamedObject
    {
        public Blueprint(string nameText, BuildingPrototype prototype, Bundle cost)
        {
            Cost = cost;
            Prototype = prototype;
            NameText = nameText;
        }

        public override string NameText { get; }
        public BuildingPrototype Prototype { get; }
        public Bundle Cost { get; }
    }
}