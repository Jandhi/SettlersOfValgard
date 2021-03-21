using System.Collections.Generic;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.ui.console.color
{
    
    public class VColor : VTextObject, INamed
    {
        public static readonly List<VColor> Colors = new List<VColor>();
        // PURPLES
        public static VColor Indigo = new VColor("Indigo", 57);
        public static VColor Amethyst = new VColor("Amethyst", 5);
        public static VColor Purple = new VColor("Purple", 129);
        public static VColor Magenta = new VColor("Magenta", 163);
        public static VColor Lavender = new VColor("Lavender", 141);
        public static VColor Violet = new VColor("Violet", 177);
        public static VColor Peach = new VColor("Peach", 174);
        public static VColor Rosewater = new VColor("Rosewater", 181);
        public static VColor Hotpink = new VColor("Hotpink", 198);
        public static VColor Thistle = new VColor("Thistle", 182);
        public static VColor Orchid = new VColor("Orchid", 213);
        
        // REDS
        public static VColor Red = new VColor("Red", 9);
        public static VColor Cherry = new VColor("Cherry", 125);
        public static VColor Crimson = new VColor("Crimson", 124);
        public static VColor Maroon = new VColor("Maroon", 1);
        public static VColor India = new VColor("India", 203);
        public static VColor Salmon = new VColor("Salmon", 210);
        
        // BROWNS
        public static VColor Fur = new VColor("Fur", 130);
        public static VColor Wood = new VColor("Wood", 94);
        public static VColor Tan = new VColor("Tan", 180);
        public static VColor Caramel = new VColor("Caramel", 136);
        public static VColor Thatch = new VColor("Thatch", 58);
        public static VColor Hay = new VColor("Hay", 101);

        // ORANGES
        public static VColor Glow = new VColor("Glow", 216);
        public static VColor Orange = new VColor("Orange", 208);
        public static VColor Grapefruit = new VColor("Grapefruit", 202);
        
        
        // YELLOWS
        public static VColor Yellow = new VColor("Yellow", 11);
        public static VColor Brass = new VColor("Brass", 178);
        public static VColor Gold = new VColor("Gold", 228);
        public static VColor Wheat = new VColor("Wheat", 229);
        public static VColor Lemon = new VColor("Lemon", 191);
        
        // GREENS
        public static VColor Shell = new VColor("Shell", 151);
        public static VColor Pear = new VColor("Pear", 154);
        public static VColor Chartreuse = new VColor("Chartreuse", 118);
        public static VColor Seaweed = new VColor("Seaweed", 114);
        public static VColor Grass = new VColor("Grass", 107);
        public static VColor Leaf = new VColor("Leaf", 70);
        public static VColor Olive = new VColor("Olive", 64);
        public static VColor Lime = new VColor("Lime", 10);
        public static VColor Green = new VColor("Green", 40);
        public static VColor Woods = new VColor("Woods", 28);
        public static VColor DarkGreen = new VColor("Dark Green", 22);
        public static VColor Jade = new VColor("Jade", 42);
        
        // TURQUOISE
        public static VColor Riptide = new VColor("Riptide", 24);
        public static VColor Turquoise = new VColor("Turquoise", 30);
        public static VColor Marsh = new VColor("Marsh", 23);
        public static VColor Atoll = new VColor("Atoll", 44);
        
        // BLUES
        public static VColor Crystal = new VColor("Crystal", 117);
        public static VColor Aquamarine = new VColor("Aquamarine", 122);
        public static VColor Sky = new VColor("Sky", 111);
        public static VColor Ice = new VColor("Ice", 159);
        public static VColor Snow = new VColor("Snow", 195);
        public static VColor Blueberry = new VColor("Blueberry", 105);
        public static VColor Wind = new VColor("Wind", 75);
        public static VColor Ocean = new VColor("Ocean", 69);
        public static VColor RoyalBlue = new VColor("Royal Blue", 63);
        public static VColor Lake = new VColor("Lake", 39);
        public static VColor Azure = new VColor("Azure", 32);
        public static VColor Sapphire = new VColor("Sapphire", 26);
        public static VColor Blue = new VColor("Blue", 21);
        public static VColor Navy = new VColor("Navy", 18);
        
        // GREYS
        public static VColor Black = new VColor("Black", 16);
        public static VColor Night = new VColor("Night", 233);
        public static VColor Steel = new VColor("Steel", 146);
        public static VColor Stone = new VColor("Stone", 145);
        public static VColor Silver = new VColor("Silver", 7);
        public static VColor Grey = new VColor("Grey", 8);
        public static VColor Iron = new VColor("Iron", 238);
        public static VColor Meteor = new VColor("Meteor", 236);
        public static VColor Mithril = new VColor("Mithril", 252);
        
        // WHITES
        public static VColor Eggshell = new VColor("Eggshell", 253);
        public static VColor White = new VColor("White", 15);
        
        //VColor Class
        public int Value { get; }
        public VText Name => new VTextSegment(Text, this);

        //VTextObject Display settings
        public override string Text { get; }
        public override VColor ForegroundColor => this;

        public VColor(string nameText, int value)
        {
            Text = nameText;
            Value = value;
            Colors.Add(this);
        }

        public string GetForegroundAnsi()
        {
            return GetForegroundAnsi(Value);
        }

        public string GetBackgroundAnsi()
        {
            return GetBackgroundAnsi(Value);
        }

        public static string GetForegroundAnsi(int number)
        {
            return "\u001b[38;5;" + number + "m";
        }

        public static string GetBackgroundAnsi(int number)
        {
            return "\u001b[48;5;" + number + "m";
        }
    }
}