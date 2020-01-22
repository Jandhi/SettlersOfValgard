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

    public enum Trait
    {
        
    }
    
    public class Settler : INamed, IAgeable, IDoesRoutines, ISkillIncreaseListener
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
                return Age.Years < ElderAge ? LifeStage.Adult : LifeStage.Elder;
            }
        }
        
        public WorkBuilding Work { get; set; }
        public ResidentialBuilding Home { get; set; }

        private bool _idle = false;

        public Settler(string name, int years)
        {
            Name = name;
            Age = new Age(years);
        }


        public void DayRoutine()
        {
            if (Age.IsBirthday())
            {
                SettlerEvents.Birthday(this);
            }

            if (Work != null)
            {
                _idle = false;
            }
            else
            {
                _idle = true;
                SettlerEvents.Idle(this);
                Settlement.Get().IdleCount++;
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
            if (resource != null && stockpile.Remove(resource, 1))
            {
                Settlement.Get().EatCount++;
                SettlerEvents.Ate(this, resource); // Ate
            }
            else
            {
                SettlerEvents.Starved(this); // Starve
            }
        }

        public void SkillIncreased(Skill skill)
        {
            SettlerEvents.SkillIncreased(this, skill);
        }

        public override string ToString()
        {
            var contents = "{0}";
            return string.Format(contents, Name);
        }
    }
}