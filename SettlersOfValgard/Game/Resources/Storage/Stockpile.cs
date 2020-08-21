using System.Linq;
using SettlersOfValgard.Game.Resources.Assets;

namespace SettlersOfValgard.Game.Resources
{
    /*
     * A bundle with size limits
     */
    public class Stockpile : Bundle
    {
        public Stockpile(int maxSize)
        {
            MaxSize = maxSize;
        }

        public int MaxSize { get; set; }

        public int Size => this.Aggregate(0, (total, next) => total + next.Key.Size * next.Value);
        public int Space => MaxSize - Size;
        

        //Adds as much as possible, returns rest
        public Bundle Add(Bundle bundle, Settlement settlement)
        {
            var leftovers = new Bundle();
            foreach (var (resource, amount) in bundle)
            {
                if (resource is Asset asset)
                {
                    leftovers.Add(asset, Add(asset, amount, settlement));
                }
                else
                {
                    leftovers.Add(resource, Add(resource, amount, settlement));
                }
            }

            return leftovers;
        }

        public int Add(Resource resource, int amount, Settlement settlement)
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

        //Overload
        public int Add(Asset asset, int amount, Settlement settlement)
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