using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Resources.Food;
using SettlersOfValgard.Game.Resources.Material;
using SettlersOfValgard.Interface.Console;

namespace SettlersOfValgard
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Bundle{{Material.Wood, 1}};
            var b = new Bundle{{Food.Meat, 3}};
            VConsole.WriteLine($"{a} + {b} = {a + b}");
        }
    }
}