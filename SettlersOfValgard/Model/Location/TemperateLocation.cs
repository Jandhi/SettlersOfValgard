using System;
using SettlersOfValgard.Model.Location.Weather;

namespace SettlersOfValgard.Model.Location
{
    public class TemperateLocation : Location
    {
        public override Weather.Weather GenerateWeather()
        {
            /*
             * 40% Clear
             * 20% Cloudy
             * 25% Light Rain
             * 10% Heavy Rain
             * 5% Storm
             */
            var rand = new Random().NextDouble();
            if (rand < 0.6)
            {
                return new Weather.Weather(Temperature.Mild, Precipitation.Clear);
            }

            if (rand < 0.4)
            {
                return new Weather.Weather(Temperature.Mild, Precipitation.Cloudy);
            }

            if (rand < 0.15)
            {
                if (rand < 0.25)
                {
                    return new Weather.Weather(Temperature.Mild, Precipitation.LightRain);
                }

                return new Weather.Weather(Temperature.Cool, Precipitation.LightRain);
            }

            if (rand < 0.05)
            {
                return new Weather.Weather(Temperature.Cool, Precipitation.HeavyRain);
            }

            return new Weather.Weather(Temperature.Cool, Precipitation.Storm);
        }
    }
}