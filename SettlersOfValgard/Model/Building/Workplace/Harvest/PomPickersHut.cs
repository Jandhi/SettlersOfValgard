using System.Collections.Generic;
using SettlersOfValgard.Model.Resource.Food;
using SettlersOfValgard.Model.Settler.Skill;

namespace SettlersOfValgard.Model.Building.Workplace.Harvest
{
    public class PomPickersHut : Harvester
    {
        public override string Name => "PomPicker";
        public override string Description { get; }
        public override int Insulation(Settlement.Settlement settlement)
        {
            return 1;
        }

        public override Building Construct()
        {
            return new PomPickersHut();
        }

        public override int MaxWorkers => 3;
        public override Dictionary<Resource.Resource, double> BaseRates => new Dictionary<Resource.Resource, double> {{Food.Pom, 2}};
        public override Skill Skill => Skill.Hunter;

        public override double BuildingEfficiency(Settlement.Settlement settlement, Resource.Resource resource, Settler.Settler worker)
        {
            return 1;
        }
    }
}