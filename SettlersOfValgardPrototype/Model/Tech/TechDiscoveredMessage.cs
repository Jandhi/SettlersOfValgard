using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;

namespace SettlersOfValgard.Model.Tech
{
    public class TechDiscoveredMessage : Message.Message
    {
        public TechDiscoveredMessage(Tech technology)
        {
            Technology = technology;
        }

        public override MessageType Type => MessageType.Settlement;
        public override MessagePriority Priority => MessagePriority.Important;
        public Tech Technology { get; }
        public override string Contents => $"You have discovered {Technology}!";
    }
}