using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Time
{
    public class Season : CustomEnum
    {
        public static readonly Season Spring = new Season("Spring", 0, CustomConsole.Green);
        public static readonly Season Summer = new Season("Summer", 1, CustomConsole.Yellow);
        public static readonly Season Fall = new Season("Fall", 2, CustomConsole.Red);
        public static readonly Season Winter = new Season("Winter", 3, CustomConsole.Cyan);
        public static readonly Season[] Seasons = {Spring, Summer, Fall, Winter};
        
        private Season(string name, int value, string color) : base(name, value, color)
        {
        }
    }
}