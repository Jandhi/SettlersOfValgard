using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class CumulativeSettlerAteMessage : IMessage
    {
        public CumulativeSettlerAteMessage(int eatCount, Bundle meals)
        {
            EatCount = eatCount;
            Meals = meals;
        }

        public MessageType Type => MessageType.Settlement;
        public MessagePriority Priority => MessagePriority.Important;
        public int EatCount { get; }
        public Bundle Meals { get; }
        
        public void Trigger(Settlement settlement)
        {
            CustomConsole.WriteLine($"{EatCount} settlers ate. {Meals}");
        }
    }
}