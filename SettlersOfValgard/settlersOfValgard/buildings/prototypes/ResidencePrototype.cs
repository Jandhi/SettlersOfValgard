using SettlersOfValgardGame.ui.console.color;

namespace SettlersOfValgardGame.settlersOfValgard.buildings.prototypes
{
    public class ResidencePrototype : BuildingPrototype
    {
        public ResidencePrototype(string nameText, VColor nameForeground, int maxFamilies) : base(nameText, nameForeground)
        {
            MaxFamilies = maxFamilies;
        }
        
        public int MaxFamilies { get; }
        public override Building Build()
        {
            return new Residence(this);
        }
    }
}