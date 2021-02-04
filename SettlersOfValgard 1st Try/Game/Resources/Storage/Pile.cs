using System.Linq;
using SettlersOfValgard.Game.Resources.Assets;

namespace SettlersOfValgard.Game.Resources.Storage
{
    /*
     * A bundle with size limits and a side pile
     */
    public class Pile : Bundle
    {
        public Pile(int maxSize)
        {
            MaxSize = maxSize;
        }

        public int MaxSize { get; set; }
        public int Space => MaxSize - Size;
        public int Size => this.Aggregate(0, (total, next) => total + next.Key.Size * next.Value); 
        
        //Adds as much as possible, returns rest
        public Bundle AddBundleAndReturnLeftovers(Bundle bundle, Settlement settlement)
        {
            var leftovers = new Bundle();
            foreach (var (resource, amount) in bundle)
            {
                if (resource is Asset asset)
                {
                    leftovers.Add(asset, AddAssetAndReturnLeftovers(asset, amount, settlement));
                }
                else
                {
                    leftovers.Add(resource, AddResourceAndReturnLeftovers(resource, amount));
                }
            }

            return leftovers;
        }

        public int AddResourceAndReturnLeftovers(Resource resource, int amount)
        {
            if (amount * resource.Size < Space)
            {
                Add(resource, amount);
                return 0;
            }
            else
            {
                Add(resource, Space / resource.Size);
                return amount - Space / resource.Size;
            }
        }

        public int AddAssetAndReturnLeftovers(Asset asset, int amount, Settlement settlement)
        {
            var inStockpile = this.ContainsResource(asset) ? this[asset] : 0;
            var space = asset.Limit(settlement) - inStockpile;
            if (amount < space)
            {
                Add(asset, amount);
                return 0;
            }
            else
            {
                Add(asset, space);
                return amount - space;
            }
        }
    }
}