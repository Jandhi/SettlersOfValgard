using System.Linq;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Command.Cheats;
using SettlersOfValgard.View.Command.Info;
using SettlersOfValgard.View.Command.Menu;
using SettlersOfValgard.View.Command.Settlement;
using SettlersOfValgard.View.Command.Settler;

namespace SettlersOfValgard.View.Command
{
    public class CommandManager
    {
        private SettlersOfValgard.View.Command.Command[] _gameCommands =
        {
            new AddFamilyCommand(), 
            new AutoHomeCommand(),
            new BuildingCommand(),
            new BlueprintCommand(), 
            new ConstructCommand(),
            new DayCommand(),
            new GodModeCommand(),
            new HomeStatusCommand(),
            new ListCommand(), 
            new RelationshipCommand(), 
            new ResourceCommand(),
            new SettlerCommand(),
            new StatusCommand(), 
            new WorkCommand(), 
        };

        private SettlersOfValgard.View.Command.Command[] _menuCommands =
        {
            new ListCommand(), 
            new StartNewSettlementCommand()
        };

        public void FindAndExecute(string input, string [] args, Game game)
        {
            SettlersOfValgard.View.Command.Command command = FindCommand(input, game.IsInMenu);
            if (command == null)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: The command \"{input}\" does not exist!");
            }
            else if(command.NeedsGodMode && !game.IsGodMode)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: The command \"{input}\" requires {CustomConsole.DarkYellow}God Mode{CustomConsole.White} to run.");
                CustomConsole.WriteLine($"Use the command \"{new GodModeCommand().Aliases[0]}\" to enter {CustomConsole.DarkYellow}God Mode{CustomConsole.White}.");
            }
            else
            {
                if (command.NeedsValidation && !ValidateCommand(command))
                {
                    return;
                }
                
                ExecuteCommand(command, args, game);
            }
        }

        private SettlersOfValgard.View.Command.Command FindCommand(string input, bool inMenu)
        {
            //Returns command if any aliases match
            if (inMenu)
            {
                return _menuCommands.FirstOrDefault(command => command.Aliases.Any(alias => input == alias));
            }
            else
            {
                return _gameCommands.FirstOrDefault(command => command.Aliases.Any(alias => input == alias));   
            }
        }

        private bool ValidateCommand(SettlersOfValgard.View.Command.Command command)
        {
            return IOManager.GetYesNo($"Run command \"{command.Name}\"? (y/n)");
        }

        private void ExecuteCommand(SettlersOfValgard.View.Command.Command command, string [] args, Game game)
        {
            bool success = command.AttemptExecution(args, game);

            if (!success)
            {
                
            }
        }

        public SettlersOfValgard.View.Command.Command FindCommand(SettlersOfValgard.View.Command.Command commandType, bool inMenu)
        {
            foreach (var command in inMenu ? _menuCommands : _gameCommands)
            {
                if (command.GetType() == commandType.GetType())
                {
                    return command;
                }
            }

            return null;
        }
    }
}