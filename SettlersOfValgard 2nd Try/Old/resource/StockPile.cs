using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.events;

namespace SettlersOfValgard.resource
{
    public class StockPile
    {
        public Dictionary<Resource, int> Contents { get; } = new Dictionary<Resource, int>();

        public List<List<Transaction>> TransactionHistory =
            new List<List<Transaction>>();
        
        public List<Transaction> TodaysTransactions = new List<Transaction>();

        public void Add(Resource type, int amount)
        {
            TodaysTransactions.Add(new Transaction(type, amount));
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
            if (!Contents.ContainsKey(type) || Contents[type] < amount) return false;
            TodaysTransactions.Add(new Transaction(type, -1 * amount));
            Contents[type] -= amount;
            return true;

        }

        public bool Remove(ResourceBundle bundle)
        {
            if (Has(bundle))
            {
                foreach (var (key, value) in bundle.Content)
                {
                    Remove(key, value);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Has(Resource type, int amount)
        {
            return Contents.ContainsKey(type) && Contents[type] >= amount;
        }

        public bool Has(ResourceBundle bundle)
        {
            return bundle.Content.All(pair => Has(pair.Key, pair.Value));
        }

        /*
         * Finds amount of resources of category in StockPile
         */
        public int AmountOfCategory(ResourceCategory category)
        {
            var amount = 0;
            foreach (var pair in Contents)
                if (pair.Key.Category == category)
                    amount += pair.Value;

            return amount;
        }

        public Resource GreatestResourceOfCategory(ResourceCategory category)
        {
            Resource maxResource = null;
            var maxAmount = 0;
            foreach (var pair in Contents.Where(pair => pair.Key.Category == category))
                if (pair.Value >= maxAmount)
                {
                    maxResource = pair.Key;
                    maxAmount = pair.Value;
                }

            return maxResource;
        }

        public void SumTodaysTransactions()
        {
            TodaysTransactions = SumTransactions(TodaysTransactions);
        }

        public void ArchiveTransactions()
        {
            TransactionHistory.Add(TodaysTransactions);
            TodaysTransactions = new List<Transaction>();
        }

        private List<Transaction> SumTransactions(List<Transaction> transactions)
        {
            List<Transaction> newList = new List<Transaction>();
            foreach (var transaction in transactions)
            {
                AddTransaction(newList, transaction);
            }

            return newList;
        }

        private void AddTransaction(List<Transaction> transactions, Transaction transaction)
        {
            var match = transactions.FirstOrDefault(t => t.Type == transaction.Type);
            if (match != null)
            {
                match.Amount += transaction.Amount;
            } 
            else
            {
                transactions.Add(transaction);    
            }
        }

        public void DailyStockPileTally()
        {
            StockPileEvents.DailyStockPileTally(TodaysTransactions);
        }
    }
}