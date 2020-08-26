using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Game.Resources.Assets;

namespace SettlersOfValgard.Game.Resources.Storage
{
    /*
     * A pile that takes transactions and has leftovers. Settlement storage.
     */
    public class Stockpile
    {
        public Pile Contents { get; set; } // Contents
        public Bundle Leftovers { get; set; } = new Bundle();// Leftovers 
        public List<Transaction> TodaysTransactions { get; set; } = new List<Transaction>();
        public List<List<Transaction>> TransactionHistory { get; } = new List<List<Transaction>>();

        public Stockpile(int maxSize)
        {
            Contents = new Pile(maxSize);
        }

        public void AddResource(Resource res, int amount, Settlement settlement)
        {
            TodaysTransactions.Add(new Transaction(res, amount));
            Leftovers += Contents.AddBundleAndReturnLeftovers(new Bundle(res, amount), settlement);
        }

        public void AddResource(Bundle bundle, Settlement settlement)
        {
            TodaysTransactions.Add(bundle);
            Leftovers += Contents.AddBundleAndReturnLeftovers(bundle, settlement);
        }

        public bool Remove(Bundle bundle)
        {
            var hasAllResources = bundle.All(pair => Contains(pair.Key, pair.Value));
            if (hasAllResources)
            {
                TodaysTransactions.Add(bundle * -1);
                RemoveBundleInStockpile(bundle);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RemoveBundleInStockpile(Bundle bundle)
        {
            foreach (var (resource, amount) in bundle)
            {
                RemoveResourceInStockpile(resource, amount);
            }
        }

        private void RemoveResourceInStockpile(Resource resource, int amount)
        {
            var amountInLeftovers = Leftovers.ContainsResource(resource) ? Leftovers[resource] : 0;
            if (amount > amountInLeftovers)
            {
                Leftovers.Remove(resource, amountInLeftovers);
                Contents.Remove(resource, amount - amountInLeftovers);
            }
            else
            {
                Leftovers.Remove(resource, amount);
            }
        }

        public bool Contains(Resource resource, int amount)
        {
            var amountInLeftovers = Leftovers.ContainsResource(resource) ? Leftovers[resource] : 0;
            var amountInContents = Contents.ContainsResource(resource) ? Contents[resource] : 0;
            return amountInContents + amountInLeftovers >= amount;
        }

        public void ClearLeftovers()
        {
            TodaysTransactions.Add(Leftovers * -1);
            Leftovers = new Bundle();
        }

        public void ArchiveTransactions()
        {
            TransactionHistory.Add(TodaysTransactions);
            TodaysTransactions = new List<Transaction>();
            
        }
    }
}