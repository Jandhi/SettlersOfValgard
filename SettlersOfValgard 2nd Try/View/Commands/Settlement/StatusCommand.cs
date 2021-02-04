using SettlersOfValgard.Model.Resource;
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
            var settlement = game.Settlement;
            CustomConsole.TitleLine();
            CustomConsole.WriteLine($"STATUS OF {settlement.ToUpperString()}:");
            CustomConsole.WriteLine($"Population: {settlement.Settlers.Count}");
            CustomConsole.WriteLine($"Buildings: {settlement.Buildings.Count}");
            CustomConsole.TitleLine();
            CustomConsole.WriteLine($"Stockpile:");
            CustomConsole.WriteLine($"{ResourceType.Food}: {settlement.Stockpile.Where(pair => pair.Key.type == ResourceType.Food).ToBundle()} ({settlement.Stockpile.DaysUntilStarvation(settlement)} days)");
            CustomConsole.WriteLine($"{ResourceType.Material}: {settlement.Stockpile.Where(pair => pair.Key.type == ResourceType.Material).ToBundle()}");
        }
    }
}