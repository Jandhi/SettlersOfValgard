using System;
using System.Collections.Generic;
using System.Text;

namespace SettlersOfValgard.Model.Resource
{
    public class PositiveResourceLedger : ResourceLedger
    {
        public PositiveResourceLedger() {}

        public PositiveResourceLedger(Resource resource, int amount)
        {
            if (amount < 0) throw new ArgumentException($"Cannot create a Bundle with a negative amount ({amount})");
            Contents = new Dictionary<Resource, int> {{resource, amount}};
        }

        public PositiveResourceLedger(Dictionary<Resource, int> contents)
        {
            foreach (var (resource, amount) in contents)
            {
                if (amount < 0)
                {
                    throw new ArgumentException($"Cannot create a Bundle with a negative amount ({amount})");
                }
            }
            Contents = contents;
        }
        
        public virtual void Add(PositiveResourceLedger other)
        {
            foreach (var (resource, amount) in other.Contents)
            {
                if (Contents.ContainsKey(resource))
                {
                    Contents[resource] += amount;
                }
                else
                {
                    Contents.Add(resource, amount);
                }
            }
        }
        
        public bool Contains(PositiveResourceLedger other)
        {
            foreach (var (type, amount) in other.Contents)
            {
                if (!Contents.ContainsKey(type) || Contents[type] < amount)
                {
                    return false;
                }
            }

            return true;
        }
        
        public virtual bool Remove(PositiveResourceLedger other)
        {
            if (!Contains(other))
            {
                return false;
            }
            else
            {
                foreach (var (resource, amount) in other.Contents)
                {
                    Contents[resource] -= amount;
                }
                return true;
            }
        }
        
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var first = true;
            foreach (var (resource, amount) in Contents)
            {
                var start = first ? "" : "\n";
                if(amount != 0) stringBuilder.Append($"{start}{resource} x{amount}");
                if(first) first = false;
            }

            return stringBuilder.ToString();
        }
    }
}