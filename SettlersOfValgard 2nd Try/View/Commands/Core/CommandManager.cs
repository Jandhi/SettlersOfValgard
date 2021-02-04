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
using SettlersOfValgard.View.Commands.Settlement.Location;
using SettlersOfValgard.View.Commands.Settlement.Settler;
using SettlersOfValgard.View.Commands.Settlement.Stockpile;
using SettlersOfValgard.View.Commands.Settlement.Tech;

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
            new ResearchCommand(),
            new ResourceCommand(),
            new SettlerCommand(),
            new StatusCommand(),
            new TechCommand(),
            new WeatherCommand(),
        };

        public Command [] MenuCommands { get; } = 
        {
            new StartNewSettlementCommand(),
        };

        public Command[] GlobalCommands { get; } =
        {
            new ClearCommand(),
            new CommandsCommand(),
            new HelpCommand(),
        };

        public void FindAndExecute(string commandName, string[] args, Game game)
        {
            var literalCommands = GetCurrentCommandList(game).Where(c =>
                c.Aliases.Any(alias => alias == commandName)).ToList();
            var commands = GetCurrentCommandList(game).Where(c =>
                c.Aliases.Any(alias => StringsUtil.IsMatchingStartIgnoreCase(alias, commandName))).ToList();

            if (commands.Count == 0 && literalCommands.Count == 0)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: The Commmand \"{commandName}\" does not exist.");
                var command = (!game.IsInMenu ? MenuCommands : GameCommands).FirstOrDefault(com =>
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
            else if (commands.Count > 1 && literalCommands.Count == 0)
            {
                CustomConsole.WriteLine($"Commands starting with \"{commandName}\":");
                IOManager.ListInConsole(commands);
            }
            else
            {
                var command = commands[0];
            
                if (command == null)
                {
                    
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
            
            
        }

        public Command[] GetCurrentCommandList(Game game)
        {
            return ArraysUtility.Add(game.IsInMenu ? MenuCommands : GameCommands, GlobalCommands);
        }
    }
}