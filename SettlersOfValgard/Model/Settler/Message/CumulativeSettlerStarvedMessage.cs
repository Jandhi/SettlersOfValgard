using System.Collections.Generic;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.Model.Settler.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class CumulativeSettlerStarvedMessage : CumulativeMessage<SettlerStarvedMessage>
    {
        public CumulativeSettlerStarvedMessage(List<Model.Message.Message> todaysMessages) : base(todaysMessages)
        {
        }

        public override MessageType Type => MessageType.Settlement;

        public override MessagePriority Priority => MessagePriority.Important;

        public override string Contents => $"{CustomConsole.Red}{Count} settlers starved!.{CustomConsole.White}";
    }
}