using System;
using System.Runtime.InteropServices;
using SettlersOfValgardGame.ui.console;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;

namespace SettlersOfValgardGame
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            ColorLoader.Load();
            Console.WriteLine(new VTextSegment("Red text", new VColor(1)) + new VTextSegment(" and ") + new VTextSegment("green text").Apply(VTextTransform.SetForeground(new VColor(2))));
        }
    }
}