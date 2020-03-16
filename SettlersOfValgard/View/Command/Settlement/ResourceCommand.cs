using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Resource
{
    public class ResourceCommand : Command
    {
        public override string Name => "Resources";
        public override string[] Aliases { get; } = {"r", "res", "resource", "resources"};
        public override bool NeedsValidation => false;
        public override bool AvailableInMenu => false;
        protected override void Execute(string[] args, Game game)
        {
            CustomConsole.Write($"{game.Settlement.Stockpile}");
        }
    }
}