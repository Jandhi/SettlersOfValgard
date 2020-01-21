using System.Runtime.Serialization;
using SettlersOfValgard.settler;

namespace SettlersOfValgard
{
    public class Event
    {
        public enum EventType
        {
            Birthday
        }
        public Event(string contents, EventType type)
        {
            Contents = contents;
            Type = type;
        }

        public string Contents { get; }
        public EventType Type { get; }

        public static Event Birthday(Settler settler)
        {
            string contents = "It's " + Console.Cyan + "{0}'s" + Console.White + " birthday!";
            contents = string.Format(contents, settler.Name);
            return new Event(contents, EventType.Birthday);
        }
    }
}