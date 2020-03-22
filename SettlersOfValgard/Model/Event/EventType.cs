using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Event
{
    public class EventType : CustomEnum
    {
        public static readonly EventType Settler = new EventType("Settler", 0, CustomConsole.Cyan);
        public static readonly EventType Building = new EventType("Building", 1, CustomConsole.DarkYellow);
        
        private EventType(string name, int value, string color) : base(name, value, color)
        {
        }
    }
}