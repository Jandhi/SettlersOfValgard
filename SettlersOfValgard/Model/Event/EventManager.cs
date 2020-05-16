using System.Collections.Generic;
using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Event
{
    public class EventManager
    {
        public Dictionary<int, List<Event>> EventCalendar { get; }= new Dictionary<int, List<Event>>();

        public Dictionary<EventRarity, RandomEvent[]> RandomEventArrays { get; } = new Dictionary<EventRarity, RandomEvent[]>
        {
            {EventRarity.Common, RandomEvent.Common},
            {EventRarity.Rare, RandomEvent.Rare},
            {EventRarity.Legendary, RandomEvent.Legendary}
        };

        public List<Event> TodaysEvents(Settlement.Settlement settlement)
        {
            var today = settlement.TodaysDate.DaysSinceSettlement;
            PurgeYesterday(today);
            //Generate a new event if there isn't one
            return EventCalendar.ContainsKey(today) ? EventCalendar[today] : new List<Event>{Generate(settlement)};
        }

        private void PurgeYesterday(int today)
        {
            EventCalendar.Remove(today - 1);
        }

        private RandomEvent Generate(Settlement.Settlement settlement)
        {
            var today = settlement.TodaysDate.DaysSinceSettlement;
            var rarity =
                RandomUtil.WeightedPercentGet(EventRarity.Rarities, null, eventRarity => eventRarity.PercentChance);
            var ev = !(rarity == null) ? RandomUtil.Get(RandomEventArrays[rarity]) : null;
            EventCalendar.Add(today, new List<Event>{ev}); //Add Today's Event to Calendar

        return ev;
        }

        public void ExecuteTodaysEvents(Settlement.Settlement settlement)
        {
            TodaysEvents(settlement)?.ForEach(ev => ev?.Execute(settlement));
        }
    }
}