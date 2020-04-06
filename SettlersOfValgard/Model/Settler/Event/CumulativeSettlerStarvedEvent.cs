using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class CumulativeSettlerStarvedEvent : IEvent
    {
        public CumulativeSettlerStarvedEvent(int eatCount)
        {
            EatCount = eatCount;
        }

        public EventType Type => EventType.Settlement;
        public EventPriority Priority => EventPriority.Important;
        public int EatCount { get; }

        public void Trigger(Settlement settlement)
        {
            CustomConsole.WriteLine($"{CustomConsole.Red}{EatCount} settlers starved!.{CustomConsole.White}");
        }
    }
}