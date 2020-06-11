using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Health
{
    public class CauseOfDeath : CustomEnum<CauseOfDeath>
    {
        public static readonly CauseOfDeath Starvation = new CauseOfDeath("Starvation", 0, CustomConsole.Yellow);
        public static readonly CauseOfDeath SuccumbedToDisease = new CauseOfDeath("Succumbed to Disease", 1, CustomConsole.DarkGreen);
        public static readonly CauseOfDeath SuccumbedToTheirWounds = new CauseOfDeath("Succumbed to their Wounds", 1, CustomConsole.DarkRed);
        
        public CauseOfDeath(string name, int value, string color) : base(name, value, color)
        {
        }

        public override CauseOfDeath[] Values { get; } = {Starvation, SuccumbedToDisease, SuccumbedToTheirWounds};
    }
}