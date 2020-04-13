using System.Collections.Generic;
using SettlersOfValgard.Model.Event.Option;
using SettlersOfValgard.Model.Settler.Event;

namespace SettlersOfValgard.Model.Event
{
    public abstract class RandomEvent : Event
    {
        public abstract EventRarity Rarity { get; }
        public abstract bool IsAvailable(Settlement.Settlement settlement);

        public static RandomEvent[] Common = { new VengefulDuelEvent(), };
        public static RandomEvent[] Rare = { };
        public static RandomEvent[] Legendary = { };
    }
}