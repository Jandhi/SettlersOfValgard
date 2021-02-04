using SettlersOfValgard.Model.Settlement;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View
{
    public class Game : View
    {
        private readonly string _title = $"{CustomConsole.Red}Settlers of Valgard{CustomConsole.White}";

        public Settlement Settlement { get; set; }
        public string PlayerName { get; set; }
        public bool IsInMenu { get; set; } = true;
        public static string GodModeString => $"{CustomConsole.DarkYellow}God Mode{CustomConsole.White}";
        public bool IsGodMode { get; set; } = false;
        
        private bool _endGame = false;

        public override void Execute()
        {
            CustomConsole.WriteLine($"Welcome to {_title}");
            //CustomConsole.WriteLine($"Use \"{new StartNewSettlementCommand().Aliases[0]}\" to start a new Settlement!");
            while (!_endGame)
            {
                IOManager.GetCommand(this);
            }
        }
    }
}