using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Event
{
    public class EventPriority : CustomEnum
    {
        public static readonly EventPriority Negligible = new EventPriority("Negligible", 0, CustomConsole.Gray);
        public static readonly EventPriority Common = new EventPriority("Common", 1, CustomConsole.Green);
        public static readonly EventPriority Uncommon = new EventPriority("Uncommon", 2, CustomConsole.Cyan);
        public static readonly EventPriority Important = new EventPriority("Important", 3, CustomConsole.Magenta);
        public static readonly EventPriority Essential = new EventPriority("Essential", 4, CustomConsole.Red);
        public static readonly EventPriority[] Priorities = {Negligible, Common, Uncommon, Important, Essential};
        
        private EventPriority(string name, int value, string color) : base(name, value, color)
        {
        }
    }
}