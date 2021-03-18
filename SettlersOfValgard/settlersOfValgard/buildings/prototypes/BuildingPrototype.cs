using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.buildings.prototypes
{
    public abstract class BuildingPrototype : NamedObject
    {
        public BuildingPrototype(string nameText, VColor nameForeground)
        {
            NameText = nameText;
            NameForeground = nameForeground;
        }

        public override string NameText { get; }
        public override VColor NameForeground { get; }

        public abstract Building Build();
    }
}