using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Handles the diachronic management of in-game events
 */
namespace SettlersOfValgard
{
    public class EventManager
    {
        public static List<List<Event>> EventHistory { get; } = new List<List<Event>>();
        public static List<Event> TodaysEvents { get; set; } = new List<Event>();
        public static List<EventType> IgnoreEvents = new List<EventType>();

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
            foreach (var e in TodaysEvents.Where(e => !IgnoreEvents.Contains(e.Type)))
            {
                Console.WriteLine(e.Contents);
            }
        }
    }
}