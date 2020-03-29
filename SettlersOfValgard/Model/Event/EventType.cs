using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Event
{
    public class EventType : CustomEnum
    {
        public static readonly EventType Settler = new EventType("Settler", 0, CustomConsole.Cyan);
        public static readonly EventType Building = new EventType("Building", 1, CustomConsole.DarkYellow);
        public static readonly EventType Settlement = new EventType("Settlement", 2, CustomConsole.Red);

        private EventType(string name, int value, string color) : base(name, value, color)
        {
            
        }
    }
}