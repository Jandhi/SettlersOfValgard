using System.Collections.Generic;
using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Event
{
    public class EventManager
    {
        public Dictionary<int, Event> EventCalendar { get; }= new Dictionary<int, Event>();

        public Dictionary<EventRarity, RandomEvent[]> RandomEventArrays { get; } = new Dictionary<EventRarity, RandomEvent[]>
        {
            {EventRarity.Common, RandomEvent.Common},
            {EventRarity.Rare, RandomEvent.Rare},
            {EventRarity.Legendary, RandomEvent.Legendary}
        };

        public Event TodaysEvent(Settlement.Settlement settlement)
        {
            var today = settlement.TodaysDate.DaysSinceSettlement;
            PurgeYesterday(today);
            return EventCalendar.ContainsKey(today) ? EventCalendar[today] : Generate(settlement);
        }

        private void PurgeYesterday(int today)
        {
            EventCalendar.Remove(today - 1);
        }

        private RandomEvent Generate(Settlement.Settlement settlement)
        {
            var today = settlement.TodaysDate.DaysSinceSettlement;
            var rarity =
                RandomUtil.WeightedGet(EventRarity.Rarities, null, eventRarity => eventRarity.PercentChance);
            var ev = !(rarity == null) ? RandomUtil.Get(RandomEventArrays[rarity]) : null;
            EventCalendar.Add(today, ev); //Add Today's Event to Calendar
            return ev;
        }
    }
}