using System;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class BuildingCommand : Command
    {
        public override string Name => "Building";
        public override string[] Aliases { get; } = {"b", "building", "Building"};
        public override bool NeedsValidation => false;
        public override bool AvailableInMenu => false;
        protected override void Execute(string[] args, Game game)
        {
            IOManager.ListInConsole(game.Settlement.Buildings);
        }
    }
}