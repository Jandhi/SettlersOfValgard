using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;

namespace SettlersOfValgard.View.Commands.Settlement.Stockpile
{
    public class ResourceCommand : Command
    {
        public override string Name => "Resources";
        public override string[] Aliases { get; } = {"r", "resource", "resources"};
        public override string UseCommandTo => "list the contents of your stockpile.";
        public override void Execute(Game game)
        {
            CustomConsole.WriteLine($"Resources of {game.Settlement}:");
            CustomConsole.WriteLine($"{game.Settlement.Stockpile}");
        }
    }
}