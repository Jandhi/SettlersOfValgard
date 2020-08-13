using System.Collections.Generic;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Message
{
    public class CumulativeSettlerUnemployedMessage : CumulativeMessage<SettlerUnemployedMessage>
    {
        public CumulativeSettlerUnemployedMessage(List<Model.Message.Message> todaysMessages) : base(todaysMessages)
        {
        }

        public override MessageType Type => MessageType.Settlement;
        public override MessagePriority Priority => MessagePriority.Important;
        public override string Contents => $"{CustomConsole.Red}{Count} settlers are unemployed!";
    }
}