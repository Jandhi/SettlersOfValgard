using SettlersOfValgard.building;
using SettlersOfValgard.time;

namespace SettlersOfValgard.settler
{
    public class Settler : INamed, IAgeable, IDoesRoutines
    {
        public string Name { get; }
        public Age Age { get; }
        
        public WorkBuilding Work { get; set; }
        public ResidentialBuilding Home { get; set; }

        public Settler(string name, int years)
        {
            Name = name;
            Age = new Age(years);
        }


        public void DayRoutine()
        {
            if (Age.IsBirthday())
            {
                EventManager.AddEvent(Event.Birthday(this));
            }
        }

        public void EveningRoutine()
        {
            
        }

        public void NightRoutine()
        {
            
        }
    }
}