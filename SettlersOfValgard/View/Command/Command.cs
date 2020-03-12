using System;
using System.Collections.Generic;

namespace SettlersOfValgard.View.Command
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract string [] Aliases { get; }
        public abstract bool NeedsValidation { get; }
        public abstract bool AvailableInMenu { get; }
        
        protected abstract void Execute(string [] args, Game game);

        public bool AttemptExecution(string [] args, Game game)
        {
            try
            {
                Execute(args, game);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
            return true;
        }
    }
}