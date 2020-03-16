namespace SettlersOfValgard.View.Command.Settlement
{
    public class DayCommand : Command
    {
        public override string Name => "Day";
        public override string[] Aliases { get; } = {"d", "day", "Day"};
        public override bool NeedsValidation => false;
        public override bool AvailableInMenu => false;
        protected override void Execute(string[] args, Game game)
        {
            game.Settlement.PassDay();
        }
    }
}