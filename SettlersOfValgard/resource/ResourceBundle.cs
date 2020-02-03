using System.Collections.Generic;
using System.Linq;

namespace SettlersOfValgard.resource
{
    public class ResourceBundle
    {
        public Dictionary<Resource, int> Content { get; } = new Dictionary<Resource, int>();

        public ResourceBundle() // Empty bundle
        {
        }

        public ResourceBundle(Resource resource, int amount)
        {
            Content.Add(resource, amount);
        }

        public ResourceBundle(Resource[] resources, int[] amounts)
        {
            for (var i = 0; i < resources.Length && i < amounts.Length; i++)
            {
                Content.Add(resources[i], amounts[i]);
            }
        }

        public ResourceBundle(Dictionary<Resource, int> contents)
        {
            Content = contents;
        }

        public ResourceBundle Modify(Resource resource, int amount)
        {
            Content.Add(resource, amount);
            return this;
        }

        public List<string> ToList()
        {
            return Content.Select(pair => pair.Key.ToString() + " x" + pair.Value).ToList();
        }

        public string ToLine()
        {
            var s = "";
            var list = ToList();
            for (var i = 0; i < list.Count; i++)
            {
                s += list[i] + (i < (list.Count - 1) ? ", " : "");
            }
            return s;
        }

        public static ResourceBundle operator +(ResourceBundle a, ResourceBundle b)
        {
            var content = a.Content.ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var (res, amount) in b.Content) // Add B
            {
                if (content.ContainsKey(res))
                {
                    content[res] += amount;
                }
                else
                {
                    content.Add(res, amount);
                }
            }

            return new ResourceBundle();
        }

        public static ResourceBundle operator *(ResourceBundle bundle, int num)
        {
            var content = bundle.Content.ToDictionary(pair => pair.Key, pair => pair.Value * num);
            return new ResourceBundle(content);
        }

        public static bool operator ==(ResourceBundle a, ResourceBundle b)
        {
            foreach (var (res, amount) in a.Content)
            {
                if (b != null && (!b.Content.ContainsKey(res) || b.Content[res] != amount)) return false;
            }

            return true;
        }

        public static bool operator !=(ResourceBundle a, ResourceBundle b)
        {
            return !(a == b);
        }
    }
}