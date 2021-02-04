using System;

namespace SettlersOfValgard.View.OldCommand
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract string [] Aliases { get; }
        public virtual bool NeedsValidation => false;
        public virtual bool NeedsGodMode => false;
        public virtual bool AvailableInMenu => false;
        public abstract string ToolTip { get; }
        
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