using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Game.Resources
{
    //A transaction with strictly positive values
    public class Bundle : Transaction
    {
        public Bundle(Dictionary<Resource, int> items = null) : base(items)
        {
            foreach(var (res, amount) in this)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException($"Bundles cannot have non-positive amounts! ({res}: {amount})");
                }
            }
        }

        public Bundle(Resource resource, int amount)
        {
            Add(resource, amount);
        }
        
        //Adds two bundles
        public static Bundle operator +(Bundle b1, Bundle b2)
        {
            var result = new Bundle();
            foreach (var transaction in new[] {b1, b2})
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

        public new int this[Resource key]
        {
            get => base[key];
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Bundles cannot have non-positive amounts! ({key}: {value})");
                }
                base[key] = value;
            }
        }

        //Has all resources in other bundle
        public bool Contains(Bundle other)
        {
            return other.All(pair => this[pair.Key] >= pair.Value);
        }

        //Returns true if you can remove each resource in other bundle
        public bool Remove(Bundle other)
        {
            if (Contains(other))
            {
                foreach (var (resource, amount) in other)
                {
                    this[resource] -= amount;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            var list = this.Select(pair => $"x{pair.Value} {pair.Key}").ToList();
            return StringsUtility.Bracket(StringsUtility.InsertCommas(list));
        }
    }
}