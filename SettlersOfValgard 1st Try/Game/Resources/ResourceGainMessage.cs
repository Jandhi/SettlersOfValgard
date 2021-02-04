using SettlersOfValgard.Game.Info.Messages;

namespace SettlersOfValgard.Game.Resources
{
    public class ResourceGainMessage : Message
    {
        public ResourceGainMessage(int amount, Resource asset)
        {
            Amount = amount;
            Resource = asset;
        }

        public int Amount { get; }
        public Resource Resource { get; }
        public override string Content => $"+{Amount} {Resource}";
        public override MessagePriority Priority => MessagePriority.Common;
    }
}