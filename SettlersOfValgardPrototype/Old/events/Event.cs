namespace SettlersOfValgard.events
{
    public enum EventType
    {
        //Settler
        SettlerBirthday,
        SettlerAte,
        SettlerStarved,
        SettlerSkillIncrease,
        SettlerIdle,
        SettlerHomeless,
        SettlerRehomed,

        //Settlement
        SettlementStarved,
        SettlementAte,
        SettlementIdle,
        SettlementHomeless,
        
        //Stockpile
        DailyStockPileTally,
    }

    public class Event
    {
        public Event(string contents, EventType type)
        {
            Contents = contents;
            Type = type;
        }

        public string Contents { get; }
        public EventType Type { get; }
    }
}