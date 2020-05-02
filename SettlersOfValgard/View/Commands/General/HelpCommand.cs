using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.General
{
    public class HelpCommand : Command
    {
        public override string Name => "Help";
        public override string[] Aliases { get; } = {"help", "Help"};
        public override string UseCommandTo { get; }

        public override List<Argument> OptionalArguments { get; } = new List<Argument>{CommandArgument};
        private static readonly StringArgument CommandArgument = new StringArgument("Command", "The Command for which to get help");
        
        public override void Execute(Game game)
        {
            if (CommandArgument.IsFilled)
            {
                CommandHelp(game);
            }
            else
            {
                GeneralHelp(game);
            }
        }

        private void GeneralHelp(Game game)
        {
            
        }

        private void CommandHelp(Game game)
        {
            var command = IOManager.CommandManager.GetCurrentCommandList(game)
                .FirstOrDefault(com => com.Aliases.Any(alias => alias == CommandArgument.Contents));
            if (command == null)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: No command named \"{CommandArgument.Contents}\" exists!");
            }
            else
            {
                CustomConsole.WriteLine($"{command.Name.ToUpper()}");
                CustomConsole.TitleLine();
                CustomConsole.WriteLine($"Used to {command.UseCommandTo}");
                CustomConsole.WriteLine($"Format: \"{command.Aliases[0]} {command.Format}\"");
                if (command.Arguments.Count > 0)
                {
                    CustomConsole.WriteLine($"Arguments:");
                    foreach (var arg in command.Arguments)
                    {
                        CustomConsole.WriteLine($"[{arg.Name}]: {arg.Description} ({arg.Type})");
                    }
                    foreach (var arg in command.OptionalArguments)
                    {
                        CustomConsole.WriteLine($"({arg.Name}): {arg.Description} ({arg.Type})");
                    }
                }
                if (command.Tags.Count > 0)
                {
                    CustomConsole.WriteLine($"Tags:");
                    foreach (var tag in command.Tags)
                    {
                        CustomConsole.WriteLine($"\"{tag.Name}{(tag.Format.Length > 0 ? " " : "")}{tag.Format}\": {tag.UseTagTo}");
                    }
                }
            }
        }
    }
}