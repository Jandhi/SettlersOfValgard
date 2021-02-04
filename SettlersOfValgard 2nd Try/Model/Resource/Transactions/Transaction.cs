using System.Collections.Generic;
using System.Text;

namespace SettlersOfValgard.Model.Resource.Transactions
{
    public class Transaction : UnrestrictedResourceLedger
    {
        
        public Transaction()
        {
            Contents = new Dictionary<Resource, int>();
        }

        public Transaction(Resource resource, int amount)
        {
            Contents = new Dictionary<Resource, int> {{resource, amount}};
        }

        public Transaction(Dictionary<Resource, int> contents)
        {
            Contents = contents;
        }

        public Transaction(ResourceLedger bundle)
        {
            Contents = bundle.Contents;
        }

        

        /*
         * Creates new Transaction that sums the resources both in a and b
         */
        public static Transaction operator +(Transaction a, Transaction b)
        {
            var contents = new Dictionary<Resource, int>();
            
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
            
            return new Transaction(contents);
        }
        
        /*
         * Creates new Transaction that sums the resources both in a and b
         */
        public static Transaction operator -(Transaction a, Transaction b)
        {
            var contents = new Dictionary<Resource, int>();
            
            foreach (var (type, amount) in a.Contents)
            {
                contents[type] = amount;
            }

            foreach (var (type, amount) in b.Contents)
            {
                if (contents.ContainsKey(type))
                {
                    contents[type] -= amount;
                }
                else
                {
                    contents[type] = -1 * amount;
                }
            }
            
            return new Transaction(contents);
        }
        
        /*
         * Creates new Transaction that contains the resources in transaction times num
         */
        public static Transaction operator * (int num, Transaction transaction)
        {
            Dictionary<Resource, int> contents = new Dictionary<Resource, int>();
            
            foreach (var (type, amount) in transaction.Contents)
            {
                contents[type] = amount * num;
            }
            
            return new Transaction(contents);
        }
        
        /*
         * Creates new Bundle that contains the resources in bundle times num
         */
        public static Transaction operator *(Transaction transaction, int num)
        {
            Dictionary<Resource, int> contents = new Dictionary<Resource, int>();
            
            foreach (var (type, amount) in transaction.Contents)
            {
                contents[type] = amount * num;
            }
            
            return new Transaction(contents);
        }
    }
}