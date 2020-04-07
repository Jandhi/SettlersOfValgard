using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class CumulativeSettlerAteMessage : Messages.Message
    {
        public CumulativeSettlerAteMessage(int eatCount, Bundle meals)
        {
            EatCount = eatCount;
            Meals = meals;
        }

        public override MessageType Type => MessageType.Settlement;
        public override MessagePriority Priority => MessagePriority.Important;
        public int EatCount { get; }
        public Bundle Meals { get; }
        public override string Contents => $"{EatCount} settlers ate. {Meals}";
    }
}