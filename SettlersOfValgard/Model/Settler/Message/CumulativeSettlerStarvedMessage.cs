using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class CumulativeSettlerStarvedMessage : IMessage
    {
        public CumulativeSettlerStarvedMessage(int eatCount)
        {
            EatCount = eatCount;
        }

        public MessageType Type => MessageType.Settlement;
        public MessagePriority Priority => MessagePriority.Important;
        public int EatCount { get; }

        public void Trigger(Settlement settlement)
        {
            CustomConsole.WriteLine($"{CustomConsole.Red}{EatCount} settlers starved!.{CustomConsole.White}");
        }
    }
}