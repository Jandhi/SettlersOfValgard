using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class CumulativeSettlerStarvedMessage : Model.Message.Message
    {
        public CumulativeSettlerStarvedMessage(int eatCount)
        {
            EatCount = eatCount;
        }

        public override MessageType Type => MessageType.Settlement;
        public override MessagePriority Priority => MessagePriority.Important;
        public int EatCount { get; }
        public override string Contents => $"{CustomConsole.Red}{EatCount} settlers starved!.{CustomConsole.White}";
    }
}