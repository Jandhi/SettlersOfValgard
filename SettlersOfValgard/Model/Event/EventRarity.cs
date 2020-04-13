using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Event
{
    public class EventRarity : CustomEnum
    {
        public static readonly EventRarity Common = new EventRarity("Common", 0, CustomConsole.Green, 4);
        public static readonly EventRarity Rare = new EventRarity("Rare", 1, CustomConsole.Magenta, 2);
        public static readonly EventRarity Legendary = new EventRarity("Legendary", 2, CustomConsole.DarkYellow, 1);
        public static readonly EventRarity[] Rarities = {Common, Rare, Legendary};
        
        public int PercentChance { get; }
        
        private EventRarity(string name, int value, string color, int percentChance) : base(name, value, color)
        {
            PercentChance = percentChance;
        }
    }
}