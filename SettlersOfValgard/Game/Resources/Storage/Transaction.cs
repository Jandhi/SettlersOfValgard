using System.Collections;
using System.Collections.Generic;

namespace SettlersOfValgard.Game.Resources
{
    public class Transaction : IEnumerable<KeyValuePair<Resource, int>>
    {
        private Dictionary<Resource, int> Items { get; }

        public Transaction(Dictionary<Resource, int> items = null)
        {
            Items = items ?? new Dictionary<Resource, int>();
        }

        public int this[Resource key]
        {
            get => Items[key];
            set => Items[key] = value;
        }

        public void Add(Resource res, int amount)
        {
            if (Items.ContainsKey(res))
            {
                Items[res] += amount;
            }
            else if(amount != 0)
            {
                Items.Add(res, amount);
            }
        }

        public bool Remove(Resource res)
        {
            return Items.Remove(res);
        }

        public bool ContainsResource(Resource resource)
        {
            return Items.ContainsKey(resource);
        }

        //Adds two transactions
        public static Transaction operator +(Transaction t1, Transaction t2)
        {
            var result = new Transaction();
            
            foreach (var transaction in new []{t1, t2})
            {
                foreach (var (res, amount) in transaction)
                {
                    if (result.ContainsResource(res))
                    {
                        result[res] += amount;
                    }
                    else
                    {
                        result.Add(res, amount);
                    }
                }
            }

            return result;
        }

        //Multiplies transaction
        public static Transaction operator *(Transaction transaction, int multiplier)
        {
            var result = new Transaction();
            foreach (var (res, amount) in transaction)
            {
                result.Add(res, amount * multiplier);
            }

            return result;
        }

        public IEnumerator<KeyValuePair<Resource, int>> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}