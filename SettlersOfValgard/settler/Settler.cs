using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.building;
using SettlersOfValgard.events;
using SettlersOfValgard.resource;
using SettlersOfValgard.time;

namespace SettlersOfValgard.settler
{
    public enum Gender
    {
        Male,
        Female,
        NonConforming
    }

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

        private bool _idle;

        public Settler(string name, int years, Gender gender)
        {
            Name = name;
            Gender = gender;
            Age = new Age(years);
        }

        public Gender Gender { get; }

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
        public Age Age { get; }
        public List<Skill> Skills = new List<Skill>();


        public void DayRoutine()
        {
            if (Age.IsBirthday()) SettlerEvents.Birthday(this);

            if (Work != null)
            {
                _idle = false;
                Work.HostWorker(this);
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
            if (Home == null)
            {
                Settlement.Get().HomelessCount++;
                SettlerEvents.Homeless(this);
            }
        }

        public string Name { get; }

        public void GainXp(SkillType type, int amount)
        {
            foreach (var t in Skills.Where(t => t.Type == type))
            {
                t.GainXp(amount);
                return;
            }

            var skill = new Skill(this, type);
            skill.GainXp(amount);
            Skills.Add(skill);
        }

        public void SkillIncreased(Skill skill)
        {
            SettlerEvents.SkillIncreased(this, skill);
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
                Settlement.Get().StarveCount++;
                SettlerEvents.Starved(this); // Starve
            }
        }

        public void Rehome(ResidentialBuilding home)
        {
            Home = home;
            SettlerEvents.Rehomed(this, Home);
        }

        public override string ToString()
        {
            var contents = "{0} ({1}), {2}.";
            return string.Format(contents, Name, GenderSymbol(Gender), Age.Years);
        }

        public static string GenderSymbol(Gender gender)
        {
            return gender switch
            {
                Gender.Male => "M",
                Gender.Female => "F",
                _ => "X"
            };
        }
    }
}