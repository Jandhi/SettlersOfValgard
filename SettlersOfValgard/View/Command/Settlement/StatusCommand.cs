using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class StatusCommand : Command
    {
        public override string Name => "Status";
        public override string[] Aliases { get; } = {"st", "status"};
        public override bool NeedsValidation => false;
        public override bool AvailableInMenu => false;
        protected override void Execute(string[] args, Game game)
        {
            CustomConsole.WriteLine($"Status of {game.Settlement}:");
            CustomConsole.VerticalLine();
            CustomConsole.WriteLine($"Population: {game.Settlement.Settlers.Count}");
            CustomConsole.WriteLine($"Buildings: {game.Settlement.Buildings.Count}");
            CustomConsole.VerticalLine();
            CustomConsole.WriteLine($"Stockpile:");
            CustomConsole.WriteLine($"{game.Settlement.Stockpile}");
        }
    }
}