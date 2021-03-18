using SettlersOfValgardGame.settlersOfValgard.buildings.prototypes;

namespace SettlersOfValgardGame.settlersOfValgard.buildings
{
    public class Workplace : Building
    {
        public Workplace(WorkplacePrototype workplacePrototype)
        {
            WorkplacePrototype = workplacePrototype;
        }

        public WorkplacePrototype WorkplacePrototype { get; }
        public override BuildingPrototype BuildingPrototype => WorkplacePrototype;
        public int MaxWorkers => WorkplacePrototype.MaxWorkers;
    }
}