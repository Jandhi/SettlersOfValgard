using System;
using System.Text;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.UtilLibrary
{
    public class StringsUtil
    {
        public static bool IsMatchingStartIgnoreCase(string name1, string name2)
        {
            return name2.Length <= name1.Length && string.Equals(name1.Substring(0, name2.Length), name2,
                       StringComparison.CurrentCultureIgnoreCase);
        }
        
        public static bool IsMatchingStartIgnoreCase(INamed item, string name)
        {
            return name.Length <= item.Name.Length && string.Equals(item.Name.Substring(0, name.Length), name,
                              StringComparison.CurrentCultureIgnoreCase);
        }

        public static string CommaList(params string[] list)
        {
            if (list.Length == 0) return "";
            var sb = new StringBuilder(list[0]);
            for (int i = 1; i < list.Length; i++)
            {
                sb.Append($", {list[i]}");
            }

            return sb.ToString();
        }

        public static string ToUpperIgnoreColor(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i > 1 && input.Substring(i - 2, 2) == CustomConsole.ColorToken)
                {
                    sb.Append(input.Substring(i, 1));
                }
                else if (i > 0 && input.Substring(i - 1, 2) == CustomConsole.ColorToken)
                {
                    sb.Append(input.Substring(i, 1));
                }
                else
                {
                    sb.Append(input.Substring(i, 1).ToUpper());
                }
            }

            return sb.ToString();
        }
    }
}