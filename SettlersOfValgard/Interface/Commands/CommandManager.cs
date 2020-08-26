using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Interface.Commands.Arguments;
using SettlersOfValgard.Interface.Commands.Settlement;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Interface.Console.List;
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
            new RegionCommand(),
            new PassDay(),
            new SettlerCommand(),
        };
        
        public List<Command> GlobalCommands = new List<Command>
        {
            
        };

        public List<Command> CurrentCommands
        {
            get
            {
                var list = new List<Command>();
                list.AddRange(Program.isInMenu ? MenuCommands : GameCommands);
                list.AddRange(GlobalCommands);
                return list;
            }
        }

        public void GetCommand()
        {
            var input = VInput.GetArgs();
            if (input.Length == 0) return; //Don't process 0 args
            var commandName = input[0];
            var args = ArraysUtility.SubArray(input, 1);
            //FIND ALIASES
            var command = CurrentCommands.FirstOrDefault(command => command.Aliases.Any(alias => alias == commandName.ToLower()));
            if (command != null)
            {
                Attempt(command, args);
                return;
            }
            //FIND NAME
            var commandList = StringsUtility.Match(commandName, CurrentCommands);
            if (commandList.Count == 0)
            {
                new GameError($"No commands starting with \"{commandName}\" found!").Write();
            }
            else if (commandList.Count > 1)
            {
                VConsole.WriteLine($"Commands starting with \"{commandName}\":");
                new TextList<Command>(commandList).Write();
            }
            else
            {
                Attempt(commandList[0], args);
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