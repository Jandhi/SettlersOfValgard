using System.Collections.Generic;
using System.Linq;

/*
 * Handles the diachronic management of in-game events
 */
namespace SettlersOfValgard.events
{
    public class EventManager
    {
        public static List<EventType> IgnoreEvents = new List<EventType>();
        public static List<List<EventType>> IgnoreLists = new List<List<EventType>>();

        public static List<EventType> SettlerEvents = new List<EventType>(new[]
        {
            EventType.SettlerAte, EventType.SettlerBirthday, EventType.SettlerSkillIncrease,
            EventType.SettlerIdle, EventType.SettlerStarved, EventType.SettlerHomeless
        });

        public static List<EventType> SettlementEvents = new List<EventType>(new[]
        {
            EventType.SettlementAte, EventType.SettlementHomeless, EventType.SettlementStarved,
            EventType.SettlementIdle
        });

        /*
         * SettlerEvents that are bundled into Settler Events
         */
        public static List<EventType> BundledSettlerEvents = new List<EventType>(new[]
        {
            EventType.SettlerAte, EventType.SettlerIdle, EventType.SettlerStarved,
            EventType.SettlerHomeless
        });

        public static List<List<Event>> EventHistory { get; } = new List<List<Event>>();
        public static List<Event> TodaysEvents { get; set; } = new List<Event>();

        public static void InitializeLists()
        {
            IgnoreLists.Add(IgnoreEvents);
            IgnoreLists.Add(BundledSettlerEvents);
        }

        public static void AddEvent(Event e)
        {
            TodaysEvents.Add(e);
        }

        public static void ArchiveEvents()
        {
            EventHistory.Add(TodaysEvents);
            TodaysEvents = new List<Event>();
        }

        public static void ListEvents()
        {
            foreach (var e in TodaysEvents.Where(e => !IgnoreEvent(e.Type))) Console.WriteLine(e.Contents);
        }

        public static bool IgnoreEvent(EventType e)
        {
            foreach (var list in IgnoreLists)
                if (list.Contains(e))
                    return true;

            return false;
        }
    }
}