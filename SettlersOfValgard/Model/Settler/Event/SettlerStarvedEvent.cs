using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class SettlerStarvedEvent : IEvent
    {
        public SettlerStarvedEvent(Model.Settler.Settler settler)
        {
            Settler = settler;
        }

        public EventType Type => EventType.Settler;
        public EventPriority Priority => EventPriority.Uncommon;
        
        public Model.Settler.Settler Settler { get; }
        
        public void Trigger(Settlement settlement)
        {
            CustomConsole.WriteLine($"{CustomConsole.Red}{Settler} starved!{CustomConsole.White}");
        }
    }
}