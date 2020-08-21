using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SettlersOfValgard.Util
{
    public class StringsUtility
    {
        public static string InsertCommas(List<string> items)
        {
            if (items.Count < 1) return "";
            var sb = new StringBuilder(items[0]);
            for (int i = 1; i < items.Count; i++)
            {
                sb.Append($", {items[i]}");
            }
            return sb.ToString();
        }

        public static string Bracket(string input)
        {
            return $"({input})";
        }

        public static List<T> Match<T>(string input, List<T> list, string suffix = null, string contains = null) where T : INamed
        {
            var ans = list.Where(item => item.Name.ToLower().StartsWith(input.ToLower())).ToList();
            if (suffix != null) ans = ans.Where(item => item.Name.ToLower().EndsWith(suffix.ToLower())).ToList();
            if (contains != null) ans = ans.Where(item => item.Name.ToLower().Contains(contains.ToLower())).ToList();
            return ans;
        }
    }
}