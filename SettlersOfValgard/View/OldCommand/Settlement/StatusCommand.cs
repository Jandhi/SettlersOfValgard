using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class StatusCommand : OldCommand.Command
    {
        public override string Name => "Status";
        public override string[] Aliases { get; } = {"st", "status"};
        public override bool AvailableInMenu => false;
        public override string ToolTip => $"Use \"{Aliases[0]}\" to get a status report of your settlement";

        protected override void Execute(string[] args, Game game)
        {
            CustomConsole.WriteLine($"Status of {game.Settlement}:");
            CustomConsole.TitleLine();
            CustomConsole.WriteLine($"Population: {game.Settlement.Settlers.Count}");
            CustomConsole.WriteLine($"Buildings: {game.Settlement.Buildings.Count}");
            CustomConsole.TitleLine();
            CustomConsole.WriteLine($"Stockpile:");
            CustomConsole.WriteLine($"{game.Settlement.Stockpile}");
        }
    }
}