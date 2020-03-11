using SettlersOfValgard.CustomConsoleLibrary;
using SettlersOfValgard.Model;

namespace SettlersOfValgard.View
{
    public class Game : View
    {
        private readonly string Title = $"{CustomConsole.Red}Settlers of Valgard";

        private Settlement _settlement = new Settlement("Vangr");
        private bool _endGame = false;
        
        public override void Execute()
        {
            CustomConsole.WriteLine($"Welcome to {Title}");
            while (!_endGame)
            {
                IOManager.ReceiveCommmands();
            }
        }
    }
}