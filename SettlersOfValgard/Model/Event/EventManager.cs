using System.Collections.Generic;

namespace SettlersOfValgard.Model.Event
{
    public class EventManager
    {
        public List<IEvent> TodaysEvents { get; set; } = new List<IEvent>();
        public List<List<IEvent>> EventHistory { get; }  = new List<List<IEvent>>();
        
        public EventPriority ActiveEventPriorityIgnoreThreshold { get; } = EventPriority.Negligible;

        public void GoThroughEvents(Settlement settlement)
        {
            TodaysEvents.ForEach(e => e.Trigger(settlement));
        }

        public void ArchiveTodaysEvents()
        {
            EventHistory.Add(TodaysEvents);
        }

        public void ClearTodaysEvents()
        {
            TodaysEvents = new List<IEvent>();
        }
    }
}