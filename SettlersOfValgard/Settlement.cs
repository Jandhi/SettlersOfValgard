using System.Collections.Generic;
using SettlersOfValgard.building;
using SettlersOfValgard.settler;
using SettlersOfValgard.time;

namespace SettlersOfValgard
{
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
        public Age Age { get; } = new Age();

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
            
        }

        public void NightRoutine()
        {
            
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