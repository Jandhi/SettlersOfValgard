using System.Collections.Generic;
using SettlersOfValgard.View.Commands.Core;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.Settlement.Settler
{
    public class SettlerCommand : ListOrDisplayCommand<Model.Settler.Settler>
    {
        public override string Name => "Settler";
        public override string[] Aliases { get; } = {"s", "settler"};

        public override string UseCommandTo { get; } =
            "List settlers in your settlement, or display information about a specific settler.";

        public override string Type => "Settler";
        public override List<Model.Settler.Settler> GetList(Game game)
        {
            return game.Settlement.Settlers;
        }

        public override void Display(Model.Settler.Settler t)
        {
            //TODO
            throw new System.NotImplementedException();
        }
    }
}