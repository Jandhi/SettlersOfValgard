using System;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Interface.Console.List
{
    public class TextListFormat<T>
    {
        public bool IsNumbered { get; set; } = false;
        public bool IsGrouped { get; set; } = true;
        public int Indent { get; set; } = 0;
        public Func<T, string> Func { get; set; } = T => T.ToString();
    }
}