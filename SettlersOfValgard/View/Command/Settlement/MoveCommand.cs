namespace SettlersOfValgard.View.Command.Settlement
{
    public class MoveCommand : Command
    {
        public override string Name => "Move";
        public override string[] Aliases { get; } = {"mv", "move", "Move"};
        public override string ToolTip => "Use ";

        protected override void Execute(string[] args, Game game)
        {
            //TODO
        }
    }
}