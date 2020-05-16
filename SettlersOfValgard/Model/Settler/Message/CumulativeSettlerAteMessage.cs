using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.Model.Resource;

namespace SettlersOfValgard.Model.Settler.Message
{
    public class CumulativeSettlerAteMessage : Model.Message.Message
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