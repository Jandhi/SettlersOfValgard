using SettlersOfValgard.CustomConsoleLibrary;

namespace SettlersOfValgard.View.Command
{
    public class SettlerCommand : Command
    {
        public override string Name { get; } = "settler";
        public override string[] Aliases { get; } = {"s", "settler"};
        public override bool NeedsValidation { get; } = false;
        public override bool AvailableInMenu { get; } = false;

        protected override void Execute(string [] args, Game game)
        {
            if (args.Length == 0)
            {
                //TODO
                CustomConsole.WriteLine("ohp");
            }
        }
    }
}