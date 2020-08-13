using System.Collections.Generic;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.Model.Resource;

namespace SettlersOfValgard.Model.Settler.Message
{
    public class CumulativeSettlerAteMessage : CumulativeMessage<SettlerAteMessage>
    {
        public CumulativeSettlerAteMessage(List<Model.Message.Message> todaysMessages) : base(todaysMessages)
        {
        }

        public override void ProcessMessage(SettlerAteMessage tMessage)
        {
            Meals.Add(tMessage.Meal);
            base.ProcessMessage(tMessage);
        }

        public override MessageType Type => MessageType.Settlement;

        public override MessagePriority Priority => MessagePriority.Important;

        public Bundle Meals { get; } = new Bundle();

        public override string Contents => $"{Count} settlers ate. {Meals}";
    }
}