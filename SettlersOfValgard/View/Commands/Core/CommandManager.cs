using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core.Arguments;
using SettlersOfValgard.View.Commands.General;
using SettlersOfValgard.View.Commands.Menu;
using SettlersOfValgard.View.Commands.Settlement;

namespace SettlersOfValgard.View.Commands.Core
{
    public class CommandManager
    {
        public Command[] GameCommands { get; } =
        {
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
            }
            else
            {
                try
                {
                    command.AttemptExecution(args, game);
                }
                catch (FormatException e)
                {
                    CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: {e.Message}");
                    CustomConsole.WriteLine($"The format of \"{command.Name}\" is: {CustomConsole.Gray}{command.Aliases[0]} {command.Format}");
                }
            }
        }

        public Command[] GetCurrentCommandList(Game game)
        {
            return ArraysUtility.Add(game.IsInMenu ? MenuCommands : GameCommands, GlobalCommands);
        }
    }
}