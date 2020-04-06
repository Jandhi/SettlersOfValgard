using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Cheats
{
    public class GodModeCommand : Command
    {
        public override string Name => "god";
        public override string[] Aliases { get; } = {"god", "God"};
        public override bool AvailableInMenu => false;
        public override string ToolTip => $"Use \"{Aliases[0]}\" to enter {CustomConsole.DarkYellow}God Mode";
        public override bool NeedsValidation => false;
        protected override void Execute(string[] args, Game game)
        {
            game.IsGodMode = !game.IsGodMode;
            if (game.IsGodMode)
            {
                CustomConsole.WriteLine($"You are now in {CustomConsole.DarkYellow}God Mode{CustomConsole.White}");
            }
            else
            {
                CustomConsole.WriteLine($"You have exited {CustomConsole.DarkYellow}God Mode{CustomConsole.White}");
            }
        }
    }
}