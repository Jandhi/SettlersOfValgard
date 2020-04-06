using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Core;

namespace SettlersOfValgard.Model.Event
{
    public class EventManager
    {
        public List<IEvent> TodaysEvents { get; set; } = new List<IEvent>();
        public List<List<IEvent>> EventHistory { get; }  = new List<List<IEvent>>();
        public EventFilter Filter { get; } = new EventFilter();
        public EventPriority ActiveEventIgnoreThreshold { get; }

        public void GoThroughEvents(Settlement settlement)
        {
            foreach (var ev in TodaysEvents.Where(ev => Filter.OutputEvent(ev)))
            {
                ev.Trigger(settlement);
            }
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