using SettlersOfValgardGame.ui.console.color;

namespace SettlersOfValgardGame.settlersOfValgard.buildings.prototypes
{
    public class WorkplacePrototype : BuildingPrototype
    {
        public WorkplacePrototype(string nameText, VColor nameForeground, int maxWorkers) : base(nameText, nameForeground)
        {
            MaxWorkers = maxWorkers;
        }
        
        public int MaxWorkers { get; }
        
        public override Building Build()
        {
            return new Workplace(this);
        }
    }
}