using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class BlueprintCommand : Command
    {
        public override string Name => "Blueprint";
        public override string[] Aliases { get; } = {"bp", "blueprint", "Blueprint"};
        public override bool NeedsValidation => false;
        public override bool AvailableInMenu => false;
        protected override void Execute(string[] args, Game game)
        {
            CustomConsole.WriteLine("Blueprints:");
            IOManager.ListInConsole(game.Settlement.Blueprints);
        }
    }
}