using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Info.Messages
{
    /*
     * Enum for levels of priority for messages sent to player
     */
    public class MessagePriority : CustomEnum<MessagePriority>
    {
        private MessagePriority(string name, string description, int value, VColor color) : base(name, description, value, color)
        {
        }

        public static readonly MessagePriority Negligible = new MessagePriority("Negligible", "Lowest priority messages, mostly for debug purposes. Only displayed in verbose mode.", 0, VColor.Gray);
        public static readonly MessagePriority Common = new MessagePriority("Common", "The usual priority. May be ignored to lessen spam.", 1, VColor.Cyan);
        public static readonly MessagePriority Important = new MessagePriority("Important", "Urgent messages regarding the status of your settlement.", 2, VColor.Green);
        public static readonly MessagePriority Essential = new MessagePriority("Essential", "Messages that you cannot ignore.", 3, VColor.Magenta);

        public override MessagePriority[] Values => new[] {Negligible, Common, Important, Essential};
    }
}