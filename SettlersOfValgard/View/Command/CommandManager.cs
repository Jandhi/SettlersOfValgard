using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Command.Settings;
using SettlersOfValgard.View.Command.Settlement;

namespace SettlersOfValgard.View.Command
{
    public class CommandManager
    {
        public List<Command> MenuCommands { get; } = new List<Command>()
        {
            
        };
        
        public List<Command> GameCommands { get; } = new List<Command>
        {
            new AutoHomeCommand(),
            new GodModeCommand(),
            new SettlerCommand(),
        };

        public void FindAndExecute(string input, string[] args, Game game)
        {
            
            var command = (game.IsInMenu ? MenuCommands : GameCommands).FirstOrDefault(com => com.Aliases.Any(alias =>
                string.Equals(alias, input, StringComparison.CurrentCultureIgnoreCase)));
            if (command == null)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: The Commmand \"{input}\" does not exist!");
            }
            else
            {
                command.AttemptExecution(args, game);
            }
        }
    }
}