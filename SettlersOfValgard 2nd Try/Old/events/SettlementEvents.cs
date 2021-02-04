using System;

namespace SettlersOfValgard.events
{
    public static class SettlementEvents
    {
        public static void Starved(int amount)
        {
            var contents = Console.Color("{0} settlers starved today!", ConsoleColor.Red);
            contents = string.Format(contents, amount);
            EventManager.AddEvent(new Event(contents, EventType.SettlementStarved));
        }

        public static void Idle(int amount)
        {
            var contents = Console.Color("{0} settlers are idle!", ConsoleColor.Red);
            contents = string.Format(contents, amount);
            EventManager.AddEvent(new Event(contents, EventType.SettlementIdle));
        }

        public static void Homeless(int amount)
        {
            var contents = Console.Color("{0} settlers are homeless!", ConsoleColor.Red);
            contents = string.Format(contents, amount);
            EventManager.AddEvent(new Event(contents, EventType.SettlementHomeless));
        }

        public static void FedSettlers(int amount)
        {
            var contents = "Fed {0} settlers.";
            contents = string.Format(contents, amount);
            EventManager.AddEvent(new Event(contents, EventType.SettlementAte));
        }
    }
}