﻿using System;
using System.Collections.Generic;

namespace SettlersOfValgard
{
    public class Console
    {
        private static string ColorToken { get; } = "`c";

        public static string Black { get; } = ColorToken + "k";
        public static string DarkBlue { get; } = ColorToken + "B";
        public static string DarkGreen { get; } = ColorToken + "G";
        public static string DarkCyan { get; } = ColorToken + "C";
        public static string DarkRed { get; } = ColorToken + "R";
        public static string DarkMagenta { get; } = ColorToken + "M";
        public static string DarkYellow { get; } = ColorToken + "Y";
        public static string DarkGray { get; } = ColorToken + "A";
        public static string Blue { get; } = ColorToken + "b";
        public static string Green { get; } = ColorToken + "g";
        public static string Cyan { get; } = ColorToken + "c";
        public static string Red { get; } = ColorToken + "r";
        public static string Magenta { get; } = ColorToken + "m";
        public static string Yellow { get; } = ColorToken + "y";

        public static string White { get; } = ColorToken + "w";
        public static void WriteLine(string s = "")
        {
            var chunks = new List<string>();
            int start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s.Substring(i).StartsWith(ColorToken) && i - start > 0)
                {
                    chunks.Add(s.Substring(start, i - start));
                    s = s.Substring(i);
                }
            }

            if (s.Length > 0)
            {
                chunks.Add(s);
            }

            var colorPairs = new List<KeyValuePair<ConsoleColor, string>>();
            foreach (var chunk in chunks)
            {
                if (chunk.StartsWith(ColorToken))
                {
                    colorPairs.Add(new KeyValuePair<ConsoleColor, string>(StringToColor(chunk.Substring(0, 3)), chunk.Substring(3)));
                }
                else
                {
                    colorPairs.Add(new KeyValuePair<ConsoleColor, string>(ConsoleColor.White, chunk));
                }
            }

            foreach (var pair in colorPairs)
            {
                System.Console.ForegroundColor = pair.Key;
                System.Console.Write(pair.Value);
            }

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine();
        }

        public static ConsoleColor StringToColor(string s)
        {
            if (s == Black) return ConsoleColor.Black;
            if (s == DarkBlue) return ConsoleColor.DarkBlue;
            if (s == DarkGreen) return ConsoleColor.DarkGreen;
            if (s == DarkCyan) return ConsoleColor.DarkCyan;
            if (s == DarkRed) return ConsoleColor.DarkRed;
            if (s == DarkMagenta) return ConsoleColor.DarkMagenta;
            if (s == DarkYellow) return ConsoleColor.DarkYellow;
            if (s == DarkGray) return ConsoleColor.DarkGray;
            if (s == Blue) return ConsoleColor.Blue;
            if (s == Green) return ConsoleColor.Green;
            if (s == Cyan) return ConsoleColor.Cyan;
            if (s == Red) return ConsoleColor.Red;
            if (s == Magenta) return ConsoleColor.Magenta;
            if (s == Yellow) return ConsoleColor.Yellow;
            return ConsoleColor.White; // default is white
        }

        public static void Clear()
        {
            System.Console.Clear();
        }

        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}