using SettlersOfValgard.Model.Settler.Event;

namespace SettlersOfValgard.Model.Event
{
    public class EventFilter
    {
        private bool AccumulateSettlerAteEvents { get; } = true;
        private bool AccumulateSettlerStarvedEvents { get; } = false;
        public EventPriority OutputThreshold { get; } = EventPriority.Negligible;
        
        public bool OutputEvent(IEvent ev)
        {
            if (ev is SettlerAteEvent)
            {
                return !AccumulateSettlerAteEvents;
            }

            if (ev is CumulativeSettlerAteEvent)
            {
                return AccumulateSettlerAteEvents;
            }

            if (ev is SettlerStarvedEvent)
            {
                return !AccumulateSettlerStarvedEvents;
            }

            if (ev is CumulativeSettlerStarvedEvent)
            {
                return AccumulateSettlerStarvedEvents;
            }

            return ev.Priority >= OutputThreshold;
        }
    }
}