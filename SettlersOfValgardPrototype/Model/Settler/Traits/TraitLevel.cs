using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Traits
{
    public class TraitLevel : CustomEnum<TraitLevel>
    {
        public static readonly TraitLevel VeryLow = new TraitLevel("Very Low", -3, CustomConsole.DarkRed);
        public static readonly TraitLevel Low = new TraitLevel("Low", -2, CustomConsole.Red);
        public static readonly TraitLevel BelowAverage = new TraitLevel("Below Average", -1, CustomConsole.Magenta);
        public static readonly TraitLevel Average = new TraitLevel("Average", 0, CustomConsole.Cyan);
        public static readonly TraitLevel AboveAverage = new TraitLevel("Above Average", 1, CustomConsole.Yellow);
        public static readonly TraitLevel High = new TraitLevel("High", 2, CustomConsole.Green);
        public static readonly TraitLevel VeryHigh = new TraitLevel("Very High", 3, CustomConsole.DarkYellow);
        public static readonly TraitLevel[] TraitLevels = {VeryLow, Low, BelowAverage, Average, AboveAverage, High, VeryHigh};
        public override TraitLevel[] Values => TraitLevels;

        public static int Weight(TraitLevel level)
        {
            if (level == VeryLow || level == VeryHigh)
            {
                return 1;
            }

            if (level == Low || level == High)
            {
                return 2;
            }

            if (level == BelowAverage || level == AboveAverage)
            {
                return 4;
            }

            if (level == Average)
            {
                return 8;
            }

            return 0;
        }

        protected TraitLevel(string name, int value, string color) : base(name, value, color)
        {
        }
    }
}