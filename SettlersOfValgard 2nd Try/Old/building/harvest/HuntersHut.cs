using SettlersOfValgard.Old.settler;
using SettlersOfValgard.resource;
using SettlersOfValgard.settler;

namespace SettlersOfValgard.building.harvest
{
    public class HuntersHut : WorkBuilding
    {
        public override string Name => "Hunter's Hut";
        public override ResourceBundle Cost => new ResourceBundle().Modify(Resource.Wood, 5);
        public override int WorkDays => 2;
        
        public override Building BuildNew()
        {
            return new HuntersHut();
        }

        public override int MaxOccupants => 5;
        public override void HostWorker(Settler worker)
        { 
            Settlement.Get().StockPile.Add(Resource.Meat, 2);
            worker.GainXp(SkillType.Hunting, 1);
        }
    }
}