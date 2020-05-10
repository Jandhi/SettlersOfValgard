using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Location.Weather
{
    public class Precipitation : CustomEnum<Precipitation>
    {
        public static readonly Precipitation Clear = new Precipitation("Clear", 0, CustomConsole.Cyan);
        public static readonly Precipitation Cloudy = new Precipitation("Cloudy", 1, CustomConsole.Gray);
        public static readonly Precipitation LightRain = new Precipitation("Light Rain", 2, CustomConsole.Blue);
        public static readonly Precipitation LightSnow = new Precipitation("Light Snow", 2, CustomConsole.Cyan);
        public static readonly Precipitation HeavyRain = new Precipitation("Heavy Rain", 3, CustomConsole.DarkBlue);
        public static readonly Precipitation HeavySnow = new Precipitation("Heavy Snow", 3, CustomConsole.Blue);
        public static readonly Precipitation Storm = new Precipitation("Storm", 4, CustomConsole.Yellow);
        public static readonly Precipitation Blizzard = new Precipitation("Blizzard", 4, CustomConsole.DarkBlue);

        public static readonly Precipitation[] Precipitations =
            {Clear, Cloudy, LightRain, LightSnow, HeavyRain, HeavySnow, Storm, Blizzard};
        public override Precipitation[] Values => Precipitations;
        
        private Precipitation(string name, int value, string color) : base(name, value, color)
        {
        }
    }
}