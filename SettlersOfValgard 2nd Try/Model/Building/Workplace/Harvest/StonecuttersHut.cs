using System.Collections.Generic;
using SettlersOfValgard.Model.Resource.Material;
using SettlersOfValgard.Model.Settler.Skill;

namespace SettlersOfValgard.Model.Building.Workplace.Harvest
{
    public class StonecuttersHut : Harvester
    {
        public override string Name => "Stonecutter's Hut";
        public override string Description => $"A workplace for harvesting {Material.Stone}";
        public override int Insulation(Settlement.Settlement settlement)
        {
            return 1;
        }

        public override Building Construct()
        {
            return new StonecuttersHut();
        }

        public override int MaxWorkers => 5;
        public override Skill Skill => Skill.Mason;

        public override Dictionary<Resource.Resource, double> BaseRates => new Dictionary<Resource.Resource, double> {{Material.Stone, 1}};
    }
}