using SettlersOfValgard.CustomConsoleLibrary;
using SettlersOfValgard.Model;
using SettlersOfValgard.Model.Rank;

namespace SettlersOfValgard.View.Command.Menu
{
    public class StartNewSettlementCommand : Command
    {
        public override string Name { get; } = "Start New Settlement";
        public override string[] Aliases { get; } = {"s"};
        public override bool NeedsValidation { get; } = false;
        public override bool AvailableInMenu { get; } = true;
        protected override void Execute(string[] args, Game game)
        {
            CustomConsole.WriteLine($"As the snow-covered passes melt, your people have made their way to {CustomConsole.Cyan}Dalland to start a new life.");
            CustomConsole.WriteLine($"What is your name, {PlayerRank.Freeman}?");
            var playerName = IOManager.GetName();
            game.PlayerName = playerName;
            CustomConsole.WriteLine($"What shall we call our settlement, {PlayerRank.Freeman} {playerName}?");
            var settlementName = IOManager.GetName();
            game.Settlement = new Settlement(settlementName);
        }
    }
}