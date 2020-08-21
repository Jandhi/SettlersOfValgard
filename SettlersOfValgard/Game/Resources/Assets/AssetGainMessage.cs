using SettlersOfValgard.Game.Info.Messages;

namespace SettlersOfValgard.Game.Resources.Assets
{
    public class AssetGainMessage : Message
    {
        public AssetGainMessage(int amount, Asset asset)
        {
            Amount = amount;
            Asset = asset;
        }

        public int Amount { get; }
        public Asset Asset { get; }
        public override string Content => $"You have gained {Amount} {Asset}.";
        public override MessagePriority Priority => MessagePriority.Common;
    }
}