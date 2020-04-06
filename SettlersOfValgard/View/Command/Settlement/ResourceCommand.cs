using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class ResourceCommand : Command
    {
        public override string Name => "Resources";
        public override string[] Aliases { get; } = {"r", "res", "resource", "resources"};
        public override bool AvailableInMenu => false;
        public override string ToolTip => $"Use \"{Aliases[0]}\" to get the status of your settlements resources";

        protected override void Execute(string[] args, Game game)
        {
            CustomConsole.Write($"{game.Settlement.Stockpile}");
        }
    }
}