using System;
using System.Collections.Generic;
using System.Text;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Resource
{
    public class Bundle
    {
        public Dictionary<Resource, int> Contents { get; set; }

        public Bundle()
        {
            Contents = new Dictionary<Resource, int>();
        }

        public Bundle(Resource resource, int amount)
        {
            Contents = new Dictionary<Resource, int> {{resource, amount}};
        }

        public Bundle(Dictionary<Resource, int> contents)
        {
            Contents = contents;
        }

        public void Add(Bundle other)
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

        public bool Contains(Resource resource)
        {
            return Contents.ContainsKey(resource) && Contents[resource] > 0;
        }

        public bool Remove(Bundle other)
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

        public bool Contains(Bundle other)
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
    }
}