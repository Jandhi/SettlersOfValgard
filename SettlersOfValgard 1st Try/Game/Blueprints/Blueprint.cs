using System;
using System.Collections.Generic;
using SettlersOfValgard.Game.Buildings;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Blueprints
{
    public class Blueprint : INamed, IDescribed, IColored
    {
        public Blueprint(Dictionary<Resource, int> cost, Building building)
        {
            Building = building;
            Cost = new Bundle(cost);
        }
        public Blueprint(Bundle cost, Building building)
        {
            Building = building;
            Cost = cost;
        }

        public string Name => Building.Name;
        public string Description => Building.Description;
        public VColor Color => Building.Color;
        public Bundle Cost { get; }
        public Building Building { get; }
    }
}