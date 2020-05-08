using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.Model.Resource.Transactions;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Resource
{
    public class Bundle : PositiveResourceLedger
    {
        /*
         * An amount of resources that exists- a positive resource ledger that can be manipulated
         */

        public Bundle() {}

        public Bundle(Resource resource, int amount) : base(resource, amount) {}

        public Bundle(Dictionary<Resource, int> contents) : base(contents) {}

        /*
         * Creates new Bundle that contains the resources both in a and b
         */
        public static Bundle operator +(Bundle a, Bundle b)
        {
            Dictionary<Resource, int> contents = new Dictionary<Resource, int>();
            
            foreach (var (type, amount) in a.Contents)
            {
                contents[type] = amount;
            }

            foreach (var (type, amount) in b.Contents)
            {
                if (contents.ContainsKey(type))
                {
                    contents[type] += amount;
                }
                else
                {
                    contents[type] = amount;
                }
            }
            
            return new Bundle(contents);
        }
        
        /*
         * Creates new Bundle that contains the resources in bundle times num
         */
        public static Bundle operator * (int num, Bundle bundle)
        {
            Dictionary<Resource, int> contents = new Dictionary<Resource, int>();
            
            foreach (var (type, amount) in bundle.Contents)
            {
                contents[type] = amount * num;
            }
            
            return new Bundle(contents);
        }
        
        /*
         * Creates new Bundle that contains the resources in bundle times num
         */
        public static Bundle operator *(Bundle bundle, int num)
        {
            Dictionary<Resource, int> contents = new Dictionary<Resource, int>();
            
            foreach (var (type, amount) in bundle.Contents)
            {
                contents[type] = amount * num;
            }
            
            return new Bundle(contents);
        }

        public override string ToString()
        {
            if (Contents.Count == 0) return "-";
            
            var stringBuilder = new StringBuilder();
            var first = true;
            foreach (var (resource, amount) in Contents)
            {
                var start = first ? "(" : ", ";
                if(amount > 0) stringBuilder.Append($"{start}{resource} x{amount}");
                if(first) first = false;
            }

            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        public Transactions.Transaction ToTransaction()
        {
            return new Transactions.Transaction(Contents);
        }
    }
}