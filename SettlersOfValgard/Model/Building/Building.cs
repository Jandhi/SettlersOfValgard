using System;
using SettlersOfValgard.Model.Core;
using SettlersOfValgard.Model.Location.Weather;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.Model.Building
{
    public abstract class Building : INamed, IDescribed
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public Temperature DefaultTemperature { get; } = Temperature.Warm;
        public abstract int Insulation(Settlement settlement);

        public abstract Building Construct();


        public Temperature GetIndoorTemperature(Settlement settlement)
        {
            int raisedTempVal = settlement.TodaysWeather.Temperature.Value + Insulation(settlement);
            int warm = Temperature.Warm.Value;
            return Temperature.Temperatures[Math.Min(raisedTempVal, warm)];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}