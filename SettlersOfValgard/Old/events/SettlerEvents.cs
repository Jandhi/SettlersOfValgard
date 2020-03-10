using System;
using SettlersOfValgard.building;
using SettlersOfValgard.Old.settler;
using SettlersOfValgard.resource;
using SettlersOfValgard.settler;

namespace SettlersOfValgard.events
{
    public class SettlerEvents
    {
        public static ConsoleColor SettlerColor = ConsoleColor.Cyan;

        public static void Birthday(Settler settler)
        {
            var contents = "It's {0}'s birthday!";
            contents = string.Format(contents, Console.Color(settler.Name, SettlerColor));
            EventManager.AddEvent(new Event(contents, EventType.SettlerBirthday));
        }

        public static void Ate(Settler settler, Resource resource)
        {
            var contents = "{0} ate some {1}";
            contents = string.Format(contents, Console.Color(settler.Name, SettlerColor), resource);
            EventManager.AddEvent(new Event(contents, EventType.SettlerAte));
        }

        public static void Starved(Settler settler)
        {
            var contents = "{0}" + Console.Color(" starved today!", ConsoleColor.DarkRed);
            contents = string.Format(contents, Console.Color(settler.Name, SettlerColor));
            EventManager.AddEvent(new Event(contents, EventType.SettlerStarved));
        }

        public static void SkillIncreased(Settler settler, Skill skill)
        {
            var contents = "{0} became a {1} {2}";
            contents = string.Format(contents, Console.Color(settler.Name, SettlerColor),
                Skill.LevelToString(skill.Level), Skill.AgentFromSkillType(skill.Type));
            EventManager.AddEvent(new Event(contents, EventType.SettlerSkillIncrease));
        }

        public static void Idle(Settler settler)
        {
            var contents = "{0} is idle today.";
            contents = string.Format(contents, Console.Color(settler.Name, SettlerColor));
            EventManager.AddEvent(new Event(contents, EventType.SettlerIdle));
        }

        public static void Homeless(Settler settler)
        {
            var contents = "{0}" + Console.Color(" is homeless!", ConsoleColor.Red);
            contents = string.Format(contents, Console.Color(settler.Name, SettlerColor));
            EventManager.AddEvent(new Event(contents, EventType.SettlerHomeless));
        }

        public static void Rehomed(Settler settler, ResidentialBuilding home)
        {
            var contents = "{0} moved into {1}";
            contents = string.Format(contents, Console.Color(settler.Name, SettlerColor), home.Name);
            EventManager.AddEvent(new Event(contents, EventType.SettlerRehomed));
        }
    }
}