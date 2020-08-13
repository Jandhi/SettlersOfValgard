using System;
using System.Linq;

namespace SettlersOfValgard.Interface.Console
{
    /*
     * Escape codes to create colored text
     */
    public class VColor
    {
        public static string Token { get; } = "`c";
        public static int SymbolLength => 2;
        public static VColor White { get; } = new VColor("00", ConsoleColor.White);
        public static VColor Black { get; } = new VColor("01", ConsoleColor.Black);
        public static VColor Gray { get; } = new VColor("02", ConsoleColor.Gray);
        public static VColor DarkGray { get; } = new VColor("03", ConsoleColor.DarkGray);
        public static VColor Red { get; } = new VColor("04", ConsoleColor.Red);
        public static VColor DarkRed { get; } = new VColor("05", ConsoleColor.DarkRed);
        public static VColor Blue { get; } = new VColor("06", ConsoleColor.Blue);
        public static VColor DarkBlue { get; } = new VColor("07", ConsoleColor.DarkBlue);
        public static VColor Green { get; } = new VColor("08", ConsoleColor.Green);
        public static VColor DarkGreen { get; } = new VColor("09", ConsoleColor.DarkGreen);
        public static VColor Cyan { get; } = new VColor("10", ConsoleColor.Cyan);
        public static VColor DarkCyan { get; } = new VColor("11", ConsoleColor.DarkCyan);
        public static VColor Magenta { get; } = new VColor("12", ConsoleColor.Magenta);
        public static VColor DarkMagenta { get; } = new VColor("13", ConsoleColor.DarkMagenta);
        public static VColor Yellow { get; } = new VColor("14", ConsoleColor.Yellow);
        public static VColor DarkYellow { get; } = new VColor("15", ConsoleColor.DarkYellow);


        public static VColor[] Colors =
        {
            White, Black, Gray, DarkGray, Red, DarkRed, Blue, DarkBlue, Green, DarkGreen, 
            Cyan, DarkCyan, Magenta, DarkMagenta, DarkYellow, Yellow
        };

        public VColor(string symbol, ConsoleColor color)
        {
            if (symbol.Length != SymbolLength) throw new ArgumentException($"All VColors must have symbol length 2! (given: {symbol})");
            Symbol = symbol;
            Color = color;
        }

        public string Symbol { get; }
        public ConsoleColor Color { get; }

        public static ConsoleColor GetColor(string s)
        {
            var color = Colors.FirstOrDefault(vcolor => s == Token + vcolor.Symbol)?.Color;
            return color ?? ConsoleColor.White;
        }
        
        public override string ToString()
        {
            return Token + Symbol;
        }
    }
}