using SettlersOfValgard.Model.Core;

namespace SettlersOfValgard.Model.Event
{
    public interface IEvent
    {
        EventType Type { get; }
        EventPriority Priority { get; }
        void Trigger(Settlement settlement);
    }
}