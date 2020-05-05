using System.Collections.Generic;
using SettlersOfValgard.View.Commands.Core;

namespace SettlersOfValgard.View.Commands.Settlement.Building
{
    public class BuildingCommand : ListOrDisplayCommand<Model.Building.Building>
    {
        public override string Name => "Building";
        public override string[] Aliases { get; } = {"b"};
        public override string UseCommandTo => "List buildings in your settlement, or display";
        public override string Type => "Building";

        public override List<Model.Building.Building> GetList(Game game)
        {
            return game.Settlement.Buildings;
        }

        public override void Display(Model.Building.Building t)
        {
            //TODO
        }
    }
}