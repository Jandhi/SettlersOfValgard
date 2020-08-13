using System.Collections.Generic;
using SettlersOfValgard.Game.Buildings;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Regions
{
    /*
     * A place where buildings can be built, resources harvested
     */
    public class Region : INamed, IColored, IDescribed
    {
        public Region(string name, VColor color, string description, Bundle resourceLimits, List<Building> buildings = null)
        {
            Name = name;
            Color = color;
            Description = description;
            ResourceLimits = resourceLimits;
            Buildings = buildings ?? new List<Building>();
        }

        public string Name { get; }
        public VColor Color { get; }
        public string Description { get; }
        public List<Building> Buildings { get; }
        public Bundle ResourceLimits { get; }
    }
}