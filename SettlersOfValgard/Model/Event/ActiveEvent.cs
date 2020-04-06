using SettlersOfValgard.Model.Core;

namespace SettlersOfValgard.Model.Event
{
    public abstract class ActiveEvent : IEvent
    {
        public abstract EventType Type { get; }
        public abstract EventPriority Priority { get; }

        public void Trigger(Settlement settlement)
        {
            if (settlement.EventManager.ActiveEventIgnoreThreshold <= Priority)
            {
                settlement.StopDayPass = true;
                Dialogue(settlement);
            } else
            {
                Default(settlement);
            }
        }

        public abstract void Dialogue(Settlement settlement);
        public abstract void Default(Settlement settlement);
    }
}