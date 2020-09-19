using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Game.Buildings;
using SettlersOfValgard.Game.Buildings.Home;
using SettlersOfValgard.Game.Buildings.Work;
using SettlersOfValgard.Game.Regions.Features;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Settlers;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Regions
{
    /*
     * A place where buildings can be built, resources harvested
     */
    public class Region : INamed, IColored, IDescribed
    {
        public Region(string name, VColor color, string description, List<Feature> features, List<Building> buildings = null)
        {
            Name = name;
            Color = color;
            Description = description;
            Features = features;
            Buildings = buildings ?? new List<Building>();
        }

        public string Name { get; }
        public VColor Color { get; }
        public string Description { get; }
        public List<Building> Buildings { get; }

        public List<Feature> Features { get; }

        //The settlers living in this region
        public List<Settler> Settlers => Buildings.OfType<Residence>().Aggregate(new List<Settler>(), (list, residence) =>
        {
            list.AddRange(residence.Residents);
            return list;
        });

        public void Work(Game game)
        {
            var availableFeatures = new List<Feature>(Features);
            var workplaces = Buildings.OfType<Workplace>().ToList();
            //Sort workplace by amount of workers- most workers get priority
            workplaces.Sort((workplace1, workplace2) => workplace1.Workers.Count.CompareTo(workplace2.Workers.Count));
            
        }
    }
}