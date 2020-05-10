using System;
using System.Text;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.UtilLibrary
{
    public class StringsUtil
    {
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
    }
}