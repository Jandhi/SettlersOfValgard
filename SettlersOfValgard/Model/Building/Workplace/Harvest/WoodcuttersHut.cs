using System.Collections.Generic;
using SettlersOfValgard.Model.Resource.Material;
using SettlersOfValgard.Model.Settler.Skill;

namespace SettlersOfValgard.Model.Building.Workplace.Harvest
{
    public class WoodcuttersHut : Harvester
    {
        public override string Name => "Woodcutter's Hut";
        public override string Description => "";
        public override int Insulation(Settlement.Settlement settlement)
        {
            return 1;
        }

        public override Building Construct()
        {
            return new WoodcuttersHut();
        }

        public override int MaxWorkers => 5;
        public override Skill Skill => Skill.Woodcutter;
        public override Dictionary<Resource.Resource, double> BaseRates { get; } = new Dictionary<Resource.Resource, double>{{Material.Wood, 2}};
    }
}