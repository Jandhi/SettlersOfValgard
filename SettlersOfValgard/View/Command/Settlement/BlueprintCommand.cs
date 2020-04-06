using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class BlueprintCommand : Command
    {
        public override string Name => "Blueprint";
        public override string[] Aliases { get; } = {"bp", "blueprint", "Blueprint"};
        public override bool AvailableInMenu => false;

        public override string ToolTip =>
            $"Use \"{Aliases[0]}\" to list your available blueprints, or \"{Aliases[0]} [name]\" to show a specific blueprint.";

        protected override void Execute(string[] args, Game game)
        {
            CustomConsole.WriteLine("Blueprints:");
            CustomConsole.VerticalLine();
            IOManager.ListInConsole(game.Settlement.Blueprints);
        }
    }
}