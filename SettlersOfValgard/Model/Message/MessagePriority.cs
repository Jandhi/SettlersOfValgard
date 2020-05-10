using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Event
{
    public class MessagePriority : CustomEnum<MessagePriority>
    {
        public static readonly MessagePriority Negligible = new MessagePriority("Negligible", 0, CustomConsole.Gray);
        public static readonly MessagePriority Common = new MessagePriority("Common", 1, CustomConsole.Green);
        public static readonly MessagePriority Uncommon = new MessagePriority("Uncommon", 2, CustomConsole.Cyan);
        public static readonly MessagePriority Important = new MessagePriority("Important", 3, CustomConsole.Magenta);
        public static readonly MessagePriority Essential = new MessagePriority("Essential", 4, CustomConsole.Red);
        public static readonly MessagePriority[] Priorities = {Negligible, Common, Uncommon, Important, Essential};
        public override MessagePriority[] Values => Priorities;


        private MessagePriority(string name, int value, string color) : base(name, value, color)
        {
        }
    }
}