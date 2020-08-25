using SettlersOfValgard.Game.Testing;
using SettlersOfValgard.Interface.Commands;

namespace SettlersOfValgard
{
    static class Program
    {
        public static CommandManager CommandManager { get; } = new CommandManager(); 
        public static bool stopGame = false;
        public static bool isInMenu = false; // Not starting in menu yet
        public static bool isDebug = true;
        public static Game.Game Game;

        static void Main(string[] args)
        {
            Game = new Game.Game(new TestSettlement());
            while (!stopGame)
            {
                CommandManager.GetCommand();
            }
        }
    }
}