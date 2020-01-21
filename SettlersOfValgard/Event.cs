using System;
using System.Runtime.Serialization;
using SettlersOfValgard.resource;
using SettlersOfValgard.settler;

namespace SettlersOfValgard
{
    public enum EventType
    {
        Birthday,
        SettlerAte,
        SettlerStarved,
        SettlerSkillIncrease
    }
    
    public class Event
    {
        public Event(string contents, EventType type)
        {
            Contents = contents;
            Type = type;
        }

        public string Contents { get; }
        public EventType Type { get; }

        
    }
}