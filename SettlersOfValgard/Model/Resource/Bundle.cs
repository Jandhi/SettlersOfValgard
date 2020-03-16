using System;
using System.Collections.Generic;
using System.Text;
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

        public Bundle(Dictionary<Resource, int> contents)
        {
            Contents = contents;
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

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (var (resource, amount) in Contents)
            {
                if(amount > 0) s.AppendLine($"{resource} x{amount}");
            }

            return s.ToString();
        }
    }
}