using SettlersOfValgard.Util;

namespace SettlersOfValgard.Interface.Commands.Settlement
{
    public class PassDay : Command
    {
        public override string Name => "EndDay";
        public override string[] Aliases => new[] {"d"};
        public override string UseCommandTo => "move on to the next day";
        public override void Execute(Game.Game game)
        {
            game.PassDay();
        }
    }
}