using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.building;
using SettlersOfValgard.resource;
using SettlersOfValgard.settler;
using SettlersOfValgard.time;

namespace SettlersOfValgard
{

    public enum PlayerRank
    {
        
    }
    public class Settlement : INamed, IAgeable, IDoesRoutines
    {
        private static Settlement _singleton = new Settlement();
        public static Settlement Get()
        {
            return _singleton;
        }

        private Settlement() {}
        
        public string Name { get; set; }
        
        public List<Settler> Settlers = new List<Settler>();
        public List<Building> Buildings = new List<Building>();
        public StockPile StockPile = new StockPile();
        public Age Age { get; } = new Age();
        
        public int EatCount = 0;
        public int IdleCount = 0;

        public void PassTime()
        {
            DayRoutine();
            EveningRoutine();
            NightRoutine();
            DoAging();
        }

        public void DayRoutine()
        {
            foreach (var settler in Settlers)
            {
                settler.DayRoutine();
            }
        }

        public void EveningRoutine()
        {
            FeedSettlers();
            
            foreach (var settler in Settlers)
            {
                settler.EveningRoutine();
            }
        }

        public void NightRoutine()
        {
            
        }

        public void FeedSettlers()
        {
            foreach (var lifeStage in SettlementSettings.FeedOrder)
            {
                foreach (var settler in Settlers.Where(settler => settler.LifeStage == lifeStage))
                {
                    settler.Eat();
                }
            }
        }

        public void DoAging()
        {
            Time.Age.doAging(); // Time passes
            Age.doAging(); // Settlement ages
            foreach (var settler in Settlers) settler.Age.doAging();
            foreach (var building in Buildings) building.Age.doAging();
        }
    }
}