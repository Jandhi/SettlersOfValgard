namespace SettlersOfValgard.Model.Event
{
    public interface IEvent
    {
        public EventType Type { get; }
        public EventPriority Priority { get; }
        void Trigger(Settlement settlement);
    }
}