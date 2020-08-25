using System;
using System.Collections.Generic;
using SettlersOfValgard.Interface.Commands.Arguments;
using SettlersOfValgard.Interface.Commands.Settlement;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Interface.Commands
{
    public class CommandManager
    {
        public List<Command> MenuCommands = new List<Command>
        {
            
        };
        
        public List<Command> GameCommands = new List<Command>
        {
            new SettlerCommand(),
        };
        
        public List<Command> GlobalCommands = new List<Command>
        {
            
        };

        public void GetCommand()
        {
            var input = VInput.GetArgs();
            if (input.Length == 0) return; //Don't process 0 args
            var commandName = input[0];
            var args = ArraysUtility.SubArray(input, 1);
            var command = StringsUtility.Match(commandName, Program.isInMenu ? MenuCommands : GameCommands);
            command.AddRange(StringsUtility.Match(commandName, GlobalCommands));
            if (command.Count == 0)
            {
                new GameError($"No commands starting with \"{commandName}\" found!").Write();
            }
            else if (command.Count > 1)
            {
                VConsole.WriteLine($"Commands starting with \"{commandName}\":");
                new TextList<Command>(command).Write();
            }
            else
            {
                Attempt(command[0], args);
            }
        }

        public void Attempt(Command command, string[] args)
        {
            try
            {
                command.AttemptExecution(args, Program.Game);
            }
            catch (InputArgumentException e)
            {
                new GameError(e.Message).Write();
            }
            catch (FormatException e)
            {
                new GameError(e.Message).Write();
            }
        }
    }
}