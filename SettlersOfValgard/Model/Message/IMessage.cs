using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;

namespace SettlersOfValgard.Model.Message
{
    public interface IMessage
    {
        MessageType Type { get; }
        MessagePriority Priority { get; }
        void Trigger(Settlement settlement);
    }
}