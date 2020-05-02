using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;

namespace SettlersOfValgard.View.Commands.Settlement
{
    public class StatusCommand : Command
    {
        public override string Name => "Status";
        public override string[] Aliases { get; } = {"st", "status"};
        public override string UseCommandTo => "Get status update of your settlement";

        public override void Execute(Game game)
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