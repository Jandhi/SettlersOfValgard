using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Prestige
{
    public class PrestigeLevel : CustomEnum<PrestigeLevel>
    {
        public static readonly PrestigeLevel Nithing = new PrestigeLevel("Nithing", -3, CustomConsole.DarkRed);
        public static readonly PrestigeLevel Outcast = new PrestigeLevel("Outcast", -2, CustomConsole.Red);
        public static readonly PrestigeLevel IllRepute = new PrestigeLevel("Ill Repute", -1, CustomConsole.Gray);
        public static readonly PrestigeLevel Insignificant = new PrestigeLevel("Insignificant", 0, CustomConsole.Cyan);
        public static readonly PrestigeLevel Notable = new PrestigeLevel("Notable", 1, CustomConsole.Green);
        public static readonly PrestigeLevel Elite = new PrestigeLevel("Elite", 2, CustomConsole.Magenta);
        public static readonly PrestigeLevel Legend = new PrestigeLevel("Legend", 3, CustomConsole.DarkYellow);
        public static readonly PrestigeLevel[] Levels = {Nithing, Outcast, IllRepute, Insignificant, Notable, Elite, Legend};

        public PrestigeLevel(string name, int value, string color) : base(name, value, color)
        {
        }

        public override PrestigeLevel[] Values { get; }

        public static PrestigeLevel PrestigeToLevel(int prestige)
        {
            if (prestige < -16)
            {
                return Nithing;
            }

            if (prestige > 16)
            {
                return Legend;
            }

            if (prestige < -8)
            {
                return Outcast;
            }

            if (prestige > 8)
            {
                return Elite;
            }

            if (prestige < -2)
            {
                return IllRepute;
            }

            if (prestige > 2)
            {
                return Notable;
            }

            return Insignificant;
        }
    }
}