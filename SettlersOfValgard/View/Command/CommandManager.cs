using System.Collections.Generic;

namespace SettlersOfValgard.View
{
    public class CommandManager
    {
        private List<KeyValuePair<string, Command.Command>> _commands = new List<KeyValuePair<string, Command.Command>>();

        private bool ValidateCommand(Command.Command command)
        {
            return true;
        }

        private void ExecuteCommand(Command.Command command)
        {
            
        }
    }
}