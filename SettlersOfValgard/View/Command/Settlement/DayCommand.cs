namespace SettlersOfValgard.View.Command.Settlement
{
    public class DayCommand : Command
    {
        public override string Name => "Day";
        public override string[] Aliases { get; } = {"d", "day", "Day"};
        public override bool AvailableInMenu => false;

        public override string ToolTip =>
            $"Use \"{Aliases[0]}\" to pass a day, or \"{Aliases[0]} [num]\" to pass [num] days";

        protected override void Execute(string[] args, Game game)
        {
            game.Settlement.PassDay();
            //TODO
        }
    }
}