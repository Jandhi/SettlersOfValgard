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
            if(!EventCalendar.ContainsKey(today)) Generate(settlement);
            return EventCalendar[today];
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
            
            //Add Today's Event to Calendar if not null
            EventCalendar.Add(today, ev != null ? new List<Event> {ev} : new List<Event>());
            return ev;
        }

        public void ExecuteTodaysEvents(Settlement.Settlement settlement)
        {
            var list = TodaysEvents(settlement);
            if (list.Count > 0)
            {
                TodaysEvents(settlement).ForEach(ev => ev?.Execute(settlement));
                settlement.StopDayPass = true;
            }
        }
    }
}