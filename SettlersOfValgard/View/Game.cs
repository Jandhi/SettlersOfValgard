using SettlersOfValgard.Model;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Command.Menu;

namespace SettlersOfValgard.View
{
    public class Game : View
    {
        private readonly string _title = $"{CustomConsole.Red}Settlers of Valgard{CustomConsole.White}";

        public Settlement Settlement { get; set; }
        public string PlayerName { get; set; }
        public bool IsInMenu { get; set; } = true;
        
        private bool _endGame = false;

        public override void Execute()
        {
            CustomConsole.WriteLine($"Welcome to {_title}");
            string start = IOManager.CommandManager.FindCommand(new StartNewSettlementCommand(), true).Aliases[0];
            CustomConsole.WriteLine($"Use \"{start}\" to start a new Settlement!");
            while (!_endGame)
            {
                IOManager.GetCommand(this);
            }
        }
    }
}