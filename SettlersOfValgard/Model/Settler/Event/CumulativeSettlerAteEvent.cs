using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class CumulativeSettlerAteEvent : IEvent
    {
        public CumulativeSettlerAteEvent(int eatCount, Bundle meals)
        {
            EatCount = eatCount;
            Meals = meals;
        }

        public EventType Type => EventType.Settlement;
        public EventPriority Priority => EventPriority.Important;
        public int EatCount { get; }
        public Bundle Meals { get; }
        
        public void Trigger(Settlement settlement)
        {
            CustomConsole.WriteLine($"{EatCount} settlers ate. {Meals}");
        }
    }
}