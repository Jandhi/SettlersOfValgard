using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.settlersOfValgard.resources.bundles;

namespace SettlersOfValgardGame.settlersOfValgard.resources.storage
{
    public class Ledger : IEnumerable<(Resource, int)>
    {
        public Ledger(Dictionary<Resource, int> contents)
        {
            Contents = contents;
        }
        
        public Ledger(params (Resource, int)[] items)
        {
            Contents = new Dictionary<Resource, int>();
            foreach (var (resource, amount) in items)
            {
                Contents.Add(resource, amount);
            }
        }

        protected Dictionary<Resource, int> Contents { get; set; }

        public virtual void Add(Resource resource, int amount)
        {
            if (Contents.ContainsKey(resource))
            {
                Contents[resource] += amount;
            }
            else
            {
                Contents.Add(resource, amount);
            }
            
            if (Contents[resource] == 0)
            {
                Contents.Remove(resource);
            }
        }
        
        public static Ledger operator +(Ledger a, Ledger b)
        {
            var transaction = new Ledger();

            foreach (var (resource, amount) in a)
            {
                transaction.Add(resource, amount);
            }
            
            foreach (var (resource, amount) in b)
            {
                transaction.Add(resource, amount);
            }

            return transaction;
        }

        public Bundle ToBundle()
        {
            return new Bundle(Contents);
        }

        public IEnumerator<(Resource, int)> GetEnumerator()
        {
            foreach (var (resource, amount) in Contents)
            {
                yield return (resource, amount);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsEmpty()
        {
            return Contents.All(pair => pair.Value == 0);
        }

        public List<(Resource, int)> ToList()
        {
            var list = new List<(Resource, int)>();
            foreach (var (resource, amount) in this)
            {
                list.Add((resource, amount));
            }

            return list;
        }
    }
}