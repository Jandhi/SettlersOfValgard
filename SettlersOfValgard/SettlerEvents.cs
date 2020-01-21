using System;
using SettlersOfValgard.resource;
using SettlersOfValgard.settler;

namespace SettlersOfValgard
{
    public class SettlerEvents
    {
        public static Event Birthday(Settler settler)
        {
            string contents = "It's {0}'s birthday!";
            contents = string.Format(contents, Console.Color(settler.Name, ConsoleColor.Cyan));
            return new Event(contents, EventType.Birthday);
        }

        public static Event Ate(Settler settler, Resource resource)
        {
            string contents = "{0} ate some {1}";
            contents = string.Format(contents, Console.Color(settler.Name, ConsoleColor.Cyan), resource);
            return new Event(contents, EventType.SettlerAte);
        }

        public static Event Starved(Settler settler)
        {
            string contents = "{0}" + Console.Color(" starved today!", ConsoleColor.DarkRed);
            contents = string.Format(contents, settler);
            return new Event(contents, EventType.SettlerStarved);
        }

        public static Event SkillIncreased(Settler settler, Skill skill)
        {
            string contents = "{0} became a {1} {2}";
            contents = string.Format(contents, settler, Skill.LevelToString(skill.Level), skill.Type);
            return new Event(contents, EventType.SettlerSkillIncrease);
        }
    }
}