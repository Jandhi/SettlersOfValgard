using System;
using SettlersOfValgard.resource;
using SettlersOfValgard.settler;

namespace SettlersOfValgard
{
    public class SettlerEvents
    {
        public static void Birthday(Settler settler)
        {
            string contents = "It's {0}'s birthday!";
            contents = string.Format(contents, Console.Color(settler.Name, ConsoleColor.Cyan));
            EventManager.AddEvent(new Event(contents, EventType.Birthday));
        }

        public static void Ate(Settler settler, Resource resource)
        {
            string contents = "{0} ate some {1}";
            contents = string.Format(contents, Console.Color(settler.Name, ConsoleColor.Cyan), resource);
            EventManager.AddEvent(new Event(contents, EventType.SettlerAte));
        }

        public static void Starved(Settler settler)
        {
            string contents = "{0}" + Console.Color(" starved today!", ConsoleColor.DarkRed);
            contents = string.Format(contents, settler);
            EventManager.AddEvent(new Event(contents, EventType.SettlerStarved));
        }

        public static void SkillIncreased(Settler settler, Skill skill)
        {
            string contents = "{0} became a {1} {2}";
            contents = string.Format(contents, settler, Skill.LevelToString(skill.Level), skill.Type);
            EventManager.AddEvent(new Event(contents, EventType.SettlerSkillIncrease));
        }

        public static void Idle(Settler settler)
        {
            string contents = "{0} is idle today.";
            contents = string.Format(contents, Console.Color(settler.Name, ConsoleColor.Cyan));
            EventManager.AddEvent(new Event(contents, EventType.SettlerIdle));
        }
    }
}