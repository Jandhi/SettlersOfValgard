using System.Collections.Generic;
using System.Linq;

namespace SettlersOfValgard.resource
{
    public class StockPile
    {
        public Dictionary<Resource, int> Contents { get; } = new Dictionary<Resource, int>();

        public void Add(Resource type, int amount)
        {
            if (Contents.ContainsKey(type))
            {
                Contents[type] += amount;
            }
            else
            {
                Contents[type] = amount;
            }
        }

        public bool Remove(Resource type, int amount)
        {
            if (Contents.ContainsKey(type) && Contents[type] >= amount)
            {
                Contents[type] -= amount;
                return true;
            }

            return false;
        }

        /*
         * Finds amount of resources of category in StockPile
         */
        public int AmountOfCategory(ResourceCategory category)
        {
            int amount = 0;
            foreach (var pair in Contents)
            {
                if (pair.Key.Category == category)
                {
                    amount += pair.Value;
                }
            }

            return amount;
        }

        public Resource GreatestResourceOfCategory(ResourceCategory category)
        {
            Resource maxResource = null;
            int maxAmount = 0;
            foreach (var pair in Contents.Where(pair => pair.Key.Category == category))
            {
                if (pair.Value >= maxAmount)
                {
                    maxResource = pair.Key;
                    maxAmount = pair.Value;
                }
            }

            return maxResource;
        }
    }
}