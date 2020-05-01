using System.Collections.Generic;

namespace SettlersOfValgard.View.Command.Settings
{
    public class GodModeCommand : Command
    {
        public override string Name { get; } = "GodMode";
        public override string[] Aliases { get; } = {"god", "God"};
        public override List<Argument> Arguments { get; } = new List<Argument>();
        public override List<Argument> OptionalArguments { get; } = new List<Argument>();
        public override List<Tag> Tags { get; } = new List<Tag>();
        public override string UseCommandTo => $"toggle {Game.GodModeString}";
        
        public override void Execute(Game game)
        {
            game.IsGodMode = !game.IsGodMode;
        }
    }
}