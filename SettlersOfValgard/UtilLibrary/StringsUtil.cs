using System;
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
    }
}