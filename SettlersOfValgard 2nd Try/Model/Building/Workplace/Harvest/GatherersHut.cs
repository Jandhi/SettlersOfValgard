using System.Collections.Generic;
using SettlersOfValgard.Model.Resource.Food;
using SettlersOfValgard.Model.Resource.Material;
using SettlersOfValgard.Model.Settler.Skill;

namespace SettlersOfValgard.Model.Building.Workplace.Harvest
{
    public class GatherersHut : Harvester
    {
        public override string Name => "Gatherer's Hut";
        public override string Description => "";
        public override int Insulation(Settlement.Settlement settlement)
        {
            return 1;
        }

        public override Building Construct()
        {
            return new GatherersHut();
        }

        public override int MaxWorkers => 5;
        public override Skill Skill => Skill.Gatherer;
        public override Dictionary<Resource.Resource, double> BaseRates => new Dictionary<Resource.Resource, double>
        {
            {Food.Fruit, 0.3}, {Food.WildGreens, 0.3}, {Material.Wood, 0.5}
        };
    }
}