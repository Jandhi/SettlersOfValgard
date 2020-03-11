using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.CustomConsoleLibrary;
using SettlersOfValgard.View.Command;

namespace SettlersOfValgard.View
{
    public class CommandManager
    {
        private Command.Command[] _commands =
        {
            new SettlerCommand()
        };

        public void FindAndExecute(string input, string [] args)
        {
            Command.Command command = FindCommand(input);
            if (command == null)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: The command \"{input}\" does not exist!");
            }
            else
            {
                if (command.NeedsValidation && !ValidateCommand(command))
                {
                    return;
                }
                
                ExecuteCommand(command, args);
            }
        }

        private Command.Command FindCommand(string input)
        {
            //Returns command if any aliases match
            return _commands.FirstOrDefault(command => command.Aliases.Any(alias => input == alias));
        }

        private bool ValidateCommand(Command.Command command)
        {
            return IOManager.GetYesNo($"Run command \"{command.Name}\"? (y/n)");
        }

        private void ExecuteCommand(Command.Command command, string [] args)
        {
            bool success = command.AttemptExecution(args);

            if (!success)
            {
                
            }
        }
    }
}