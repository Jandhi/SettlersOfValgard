using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Game.Blueprints;
using SettlersOfValgard.Game.Buildings;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Resources.Storage;
using SettlersOfValgard.Game.Settlers;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game
{
    public class Settlement : INamed, IColored
    {
        public Settlement(string name, List<Settler> settlers, List<Region> regions, Stockpile stockpile, List<Blueprint> blueprints)
        {
            Name = name;
            Settlers = settlers;
            Regions = regions;
            Stockpile = stockpile;
            Blueprints = blueprints;
        }

        public string Name { get; }
        public VColor Color { get; } = VColor.Green; //TODO Update color
        public List<Settler> Settlers { get; }
        public List<Region> Regions { get; } //Regions that are a part of this settlement
        //Finds all buildings in all regions
        public List<Building> Buildings => Regions.Aggregate(
            new List<Building>(),
            (total, next) =>
            {
                total.AddRange(next.Buildings);
                return total;
            });

        public List<Blueprint> Blueprints { get; }
        
        public Stockpile Stockpile { get; } // Resources
        
        public void AddResource(Resource res, int amount)
        {
            Stockpile.AddResource(res, amount, this);
        }

        public void AddResource(Bundle bundle)
        {
            Stockpile.AddResource(bundle, this);
        }

        public bool Remove(Bundle bundle)
        {
            return Stockpile.Remove(bundle);
        }
    }
}