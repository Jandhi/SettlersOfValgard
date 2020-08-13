using System;
using System.Collections.Generic;

namespace SettlersOfValgard.Interface.Console
{
    /*
     * Implements writing in the console using VColor escape codes to create colorful text
     */
    public static class VConsole
    {
        public static void Write(string s = "")
        {
            var chunks = new List<string>();
            var start = 0;
            for (var i = 0; i < s.Length; i++)
                if (s.Substring(i).StartsWith(VColor.Token) && i - start > 0)
                {
                    chunks.Add(s.Substring(start, i - start));
                    s = s.Substring(i);
                    start = 0;
                    i = 0;
                }

            if (s.Length > 0) chunks.Add(s);

            var colorPairs = new List<KeyValuePair<ConsoleColor, string>>();
            foreach (var chunk in chunks)
                if (chunk.StartsWith(VColor.Token))
                    colorPairs.Add(new KeyValuePair<ConsoleColor, string>(VColor.GetColor(chunk.Substring(0, VColor.Token.Length + VColor.SymbolLength)),
                        chunk.Substring(VColor.Token.Length + VColor.SymbolLength)));
                else
                    colorPairs.Add(new KeyValuePair<ConsoleColor, string>(ConsoleColor.White, chunk));

            foreach (var pair in colorPairs)
            {
                System.Console.ForegroundColor = pair.Key;
                System.Console.Write(pair.Value);
            }

            System.Console.ForegroundColor = ConsoleColor.White;
        }
        
        public static void WriteLine(string s = "")
        {
            Write(s);
            System.Console.WriteLine();
        }

        public static void Clear()
        {
            System.Console.Clear();
        }
    }
}