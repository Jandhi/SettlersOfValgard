﻿using System.Collections.Generic;
using SettlersOfValgard.Model.Location.Weather;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.Model.Resource.Food;
using SettlersOfValgard.Model.Settler.Skill;

namespace SettlersOfValgard.Model.Building.Workplace.Harvest
{
    public class HuntersHut : Harvester
    {
        public override string Name => "Hunter's Hut";
        public override string Description => "Performs worse during bad weather.";
        public override Skill Skill => Skill.Hunter;

        public override int Insulation(Settlement.Settlement settlement) => 0;

        public override Building Construct() => new HuntersHut();

        public override int MaxWorkers => 5;

        public override Dictionary<Resource.Resource, double> BaseRates => new Dictionary<Resource.Resource, double> {{Food.Meat, 2}};

        public override double BuildingEfficiency(Settlement.Settlement settlement, Resource.Resource resource, Settler.Settler worker)
        {
            var precipitation = settlement.TodaysWeather.Precipitation;

            if (precipitation == Precipitation.Clear || precipitation == Precipitation.Cloudy)
            {
                return 1;
            }

            if (precipitation == Precipitation.LightSnow)
            {
                return 1.3;
            }

            if (precipitation == Precipitation.LightRain || precipitation == Precipitation.HeavySnow)
            {
                return 0.8;
            }

            if (precipitation == Precipitation.HeavyRain)
            {
                return 0.3;
            }

            if (precipitation == Precipitation.Blizzard || precipitation == Precipitation.Storm)
            {
                return 0;
            }

            return 1;
        }
    }
}