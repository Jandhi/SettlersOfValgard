using System.Collections.Generic;

namespace SettlersOfValgard.Model.Resource
{
    public class Bundle
    {
        public Dictionary<ResourceType, int> Contents { get; set; }

        public Bundle()
        {
            
        }

        public Bundle(Dictionary<ResourceType, int> contents)
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
         * Creates new Bundle that contains resources both in a and b
         */
        public static Bundle operator +(Bundle a, Bundle b)
        {
            Dictionary<ResourceType, int> contents = new Dictionary<ResourceType, int>();
            
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
    }
}