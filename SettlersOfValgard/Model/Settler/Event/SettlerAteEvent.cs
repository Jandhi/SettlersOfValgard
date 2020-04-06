using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class SettlerAteEvent : IEvent
    {
        public SettlerAteEvent(Model.Settler.Settler settler, Bundle meal)
        {
            Settler = settler;
            Meal = meal;
        }

        public EventType Type => EventType.Settler;
        public EventPriority Priority => EventPriority.Negligible;
        
        public Model.Settler.Settler Settler { get; }
        public Bundle Meal { get; }
        
        public void Trigger(Settlement settlement)
        {
            CustomConsole.WriteLine($"{Settler} ate {Meal}");
        }
    }
}