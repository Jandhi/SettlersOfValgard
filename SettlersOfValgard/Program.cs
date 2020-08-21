using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Game.Resources.Assets;
using SettlersOfValgard.Game.Resources.Food;
using SettlersOfValgard.Game.Resources.Material;
using SettlersOfValgard.Game.Testing;
using SettlersOfValgard.Interface.Console;

namespace SettlersOfValgard
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game.Game(new TestSettlement());
        }
    }
}