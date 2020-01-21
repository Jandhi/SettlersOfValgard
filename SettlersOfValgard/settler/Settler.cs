using SettlersOfValgard.building;
using SettlersOfValgard.resource;
using SettlersOfValgard.time;

namespace SettlersOfValgard.settler
{
    public enum LifeStage
    {
        Child,
        Adult,
        Elder
    }
    
    public enum Caste
    {
        Thrall,
        Karl,
        Jarl
    }
    
    public class Settler : INamed, IAgeable, IDoesRoutines
    {
        public const int AdultAge = 16;
        public const int ElderAge = 60;
        
        public string Name { get; }
        public Age Age { get; }

        public LifeStage LifeStage
        {
            get
            {
                if (Age.Years < AdultAge) return LifeStage.Child;
                if (Age.Years < ElderAge) return LifeStage.Adult;
                return LifeStage.Elder;
            }
        }
        
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
                EventManager.AddEvent(SettlerEvents.Birthday(this));
            }
        }

        public void EveningRoutine()
        {
            
        }

        public void NightRoutine()
        {
            
        }

        public void Eat()
        {
            var stockpile = Settlement.Get().StockPile;
            var resource = stockpile.GreatestResourceOfCategory(ResourceCategory.Food);
            if (resource != null && stockpile.Remove(resource, 1)) // Eats
            {
                Settlement.Get().EatCount++;
                EventManager.AddEvent(SettlerEvents.Ate(this, resource));
            }
            else
            {
                EventManager.AddEvent(SettlerEvents.Starved(this));
            }
        }

        public override string ToString()
        {
            var contents = "{0}";
            return string.Format(contents, Name);
        }
    }
}