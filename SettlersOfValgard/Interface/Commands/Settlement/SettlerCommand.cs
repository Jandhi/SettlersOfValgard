using System.Collections.Generic;
using SettlersOfValgard.Game.Settlers;
using SettlersOfValgard.Interface.Console;

namespace SettlersOfValgard.Interface.Commands.Settlement
{
    public class SettlerCommand : ListOrDescribeCommand<Settler>
    {
        public override string Name => "Settler";
        public override string[] Aliases => new[] {"s", "settlers"};
        public override List<Settler> List(Game.Game game)
        {
            return game.Settlement.Settlers;
        }

        public override void Describe(Settler item)
        {
            new Title<Settler>(item).Write();
        }

        public override string TypeName => "settler";
    }
}