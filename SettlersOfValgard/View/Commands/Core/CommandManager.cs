using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core.Arguments;
using SettlersOfValgard.View.Commands.General;
using SettlersOfValgard.View.Commands.Menu;
using SettlersOfValgard.View.Commands.Settlement;
using SettlersOfValgard.View.Commands.Settlement.Auto;
using SettlersOfValgard.View.Commands.Settlement.Building;
using SettlersOfValgard.View.Commands.Settlement.Extras;
using SettlersOfValgard.View.Commands.Settlement.Settler;
using SettlersOfValgard.View.Commands.Settlement.Stockpile;

namespace SettlersOfValgard.View.Commands.Core
{
    public class CommandManager
    {
        public Command[] GameCommands { get; } =
        {
            new AutoHomeCommand(),
            new AutoWorkCommand(),
            new BuildingCommand(),
            new BlueprintCommand(),
            new BoopCommand(),
            new ConstructCommand(),
            new HomeCommand(),
            new PassDayCommand(),
            new RelationshipCommand(),
            new ResourceCommand(),
            new SettlerCommand(),
            new StatusCommand(),
        };

        public Command [] MenuCommands { get; } = 
        {
            new StartNewSettlementCommand(),
        };

        public Command[] GlobalCommands { get; } =
        {
            new HelpCommand(),
        };

        public void FindAndExecute(string commandName, string[] args, Game game)
        {
            var command = GetCurrentCommandList(game).FirstOrDefault(com => com.Aliases.Any(alias => alias == commandName));
            if (command == null)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: The Commmand \"{commandName}\" does not exist.");
                command = (!game.IsInMenu ? MenuCommands : GameCommands).FirstOrDefault(com =>
                    com.Aliases.Any(alias => alias == commandName));
                if (command != null)
                {
                    if (game.IsInMenu)
                    {
                        CustomConsole.WriteLine($"{CustomConsole.Gray}The command \"{command}\" is not available in menu.");
                    }
                    else
                    {
                        CustomConsole.WriteLine(
                            $"{CustomConsole.Gray}The command \"{command}\" is only available in menu.");
                    }
                }
            }
            else
            {
                try
                {
                    command.AttemptExecution(args, game);
                    command.Clear();
                }
                catch (FormatException e)
                {
                    CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: {e.Message}");
                    CustomConsole.WriteLine(
                        $"The format of \"{command.Name}\" is: {CustomConsole.Gray}{command.Aliases[0]} {command.Format}");
                }
                catch (NotImplementedException e)
                {
                    CustomConsole.WriteLine($"{CustomConsole.Yellow}Sorry! This feature hasn't been implemented!");
                }
            }
        }

        public Command[] GetCurrentCommandList(Game game)
        {
            return ArraysUtility.Add(game.IsInMenu ? MenuCommands : GameCommands, GlobalCommands);
        }
    }
}