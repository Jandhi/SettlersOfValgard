using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Game.Assets;
using SettlersOfValgard.Game.Buildings;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Settlers;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game
{
    public class Settlement : INamed, IColored
    {
        public Settlement(string name, List<Settler> settlers, List<Region> regions, Stockpile stockpile)
        {
            Name = name;
            Settlers = settlers;
            Regions = regions;
            Stockpile = stockpile;
        }

        public string Name { get; }
        public VColor Color { get; } = VColor.Green; //TODO Update color
        public List<Settler> Settlers { get; }
        //Finds all unique families 
        public List<Family> Families => Settlers.Aggregate(
            new List<Family>(),
            (total, next) =>
            {
                if (!total.Contains(next.Family)) total.Add(next.Family);
                return total;
            });
        public List<Region> Regions { get; } //Regions that are a part of this settlement
        //Finds all buildings in all regions
        public List<Building> Buildings => Regions.Aggregate(
            new List<Building>(),
            (total, next) =>
            {
                total.AddRange(next.Buildings);
                return total;
            });

        public Stockpile Stockpile { get; } // Resources
        public Bundle Pile { get; set; } // Emptied every night

        public void AddResource(Resource res, int amount)
        {
            var leftovers = Stockpile.Add(new Bundle(res, amount));
            Pile += leftovers;
        }
        
        public void AddResource(Bundle bundle)
        {
            var leftovers = Stockpile.Add(bundle);
            Pile += leftovers;
        }
        
        public Dictionary<Asset, int> Assets { get; }

        public void AddAsset(Asset asset, int amount)
        {
            if (Assets.ContainsKey(asset))
            {
                Assets[asset] = Math.Min(Assets[asset] + amount, asset.Limit(this));
            }
            else
            {
                Assets.Add(asset, Math.Min(amount, asset.Limit(this)));
            }
        }
    }
}