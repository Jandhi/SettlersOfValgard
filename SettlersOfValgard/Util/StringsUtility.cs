using System.Collections.Generic;
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
    }
}