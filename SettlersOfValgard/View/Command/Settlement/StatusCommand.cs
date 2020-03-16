using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Resource
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
            CustomConsole.WriteLine("----------");
            CustomConsole.WriteLine($"Population: {game.Settlement.Settlers.Count}");
            CustomConsole.WriteLine($"Buildings: {game.Settlement.Buildings.Count}");
            CustomConsole.WriteLine("----------");
            CustomConsole.WriteLine($"Stockpile:");
            CustomConsole.Write($"{game.Settlement.Stockpile}");
        }
    }
}