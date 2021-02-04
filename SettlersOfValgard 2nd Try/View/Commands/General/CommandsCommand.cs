using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;

namespace SettlersOfValgard.View.Commands.General
{
    public class CommandsCommand : Command
    {
        public override string Name => "Commands";
        public override string[] Aliases { get; } = {"com", "commands"};
        public override string UseCommandTo => "list available commands";
        public override void Execute(Game game)
        {
            CustomConsole.TitleLine();
            CustomConsole.WriteLine("AVAILABLE COMMANDS:");
            foreach (var command in IOManager.CommandManager.GetCurrentCommandList(game))
            {
                CustomConsole.WriteLine($"{command} ({command.Aliases})");
            }
        }
    }
}