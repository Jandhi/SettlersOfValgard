using System.Collections.Generic;
using System.Linq;
using System.Text;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.Model.Resource.Transactions;

namespace SettlersOfValgard.Model.Resource
{
    public class Stockpile : PositiveResourceLedger
    {
        public List<Transaction> TodaysTransactions = new List<Transaction>();
        public List<List<Transaction>> TransactionHistory = new List<List<Transaction>>();
        
        public Resource GetHighestOfType(ResourceType type)
        {
            Resource max = null;
            foreach (var (resource, amount) in Contents)
            {
                if (Contains(resource) && resource.type == type)
                {
                    if (max == null)
                    {
                        max = resource;
                    }
                    else if(Contents[resource] > Contents[max])
                    {
                        max = resource;
                    }
                }
            }

            return max;
        }

        public int DaysUntilStarvation(Settlement.Settlement settlement)
        {
            //TODO update for different diets
            return Contents.Where(pair => pair.Key.type == ResourceType.Food).Aggregate(0, (sum, pair) => sum + pair.Value) / settlement.Settlers.Count;
        }

        public override void Add(PositiveResourceLedger other)
        {
            base.Add(other);
            TodaysTransactions.Add(new Transaction(other));
        }

        public override bool Remove(PositiveResourceLedger other)
        {
            if (base.Remove(other))
            {
                TodaysTransactions.Add(new Transaction(other) * -1);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddTodaysTransactionsMessage(MessageManager manager)
        {
            var transactionSum = TodaysTransactions.Aggregate(new Transaction(), (sum, next) => sum + next);
            if(!transactionSum.IsEmpty()) // Don't output no transactions
            {
                manager.TodaysMessages.Add(new TodaysTransactionsMessage(transactionSum, true));
                manager.TodaysMessages.Add(new TodaysTransactionsMessage(transactionSum, false));
            } 
            else
            {
                manager.TodaysMessages.Add(new NoTransactionsMessage());
            }
            
        }

        public void ArchiveTodaysTransactions()
        {
            TransactionHistory.Add(TodaysTransactions);
        }

        public void ClearTodaysTransactions()
        {
            TodaysTransactions = new List<Transaction>();
        }
    }
}