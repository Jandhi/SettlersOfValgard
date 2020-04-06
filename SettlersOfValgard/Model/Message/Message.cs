using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Settler.Event;

namespace SettlersOfValgard.Model.Message
{
    public class Message
    {
        private bool AccumulateSettlerAteMessages { get; } = true;
        private bool AccumulateSettlerStarvedMessages { get; } = false;
        public MessagePriority OutputThreshold { get; } = MessagePriority.Negligible;
        
        public bool OutputMessage(IMessage ev)
        {
            switch (ev)
            {
                case SettlerAteMessage _:
                    return !AccumulateSettlerAteMessages;
                case CumulativeSettlerAteMessage _:
                    return AccumulateSettlerAteMessages;
                case SettlerStarvedMessage _:
                    return !AccumulateSettlerStarvedMessages;
                case CumulativeSettlerStarvedMessage _:
                    return AccumulateSettlerStarvedMessages;
                default:
                    return ev.Priority >= OutputThreshold;
            }
        }
    }
}