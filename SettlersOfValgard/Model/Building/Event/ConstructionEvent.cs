using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Building.Event
{
    public class ConstructionEvent : IEvent
    {
        public ConstructionEvent(Building building)
        {
            Building = building;
        }

        public Building Building { get; }
        
        public EventType Type => EventType.Building;
        public EventPriority Priority => EventPriority.Uncommon;
        public void Trigger(Settlement settlement)
        {
            CustomConsole.WriteLine($"Constructed a {Building}");
        }
    }
}