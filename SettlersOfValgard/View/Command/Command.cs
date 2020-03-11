using System;

namespace SettlersOfValgard.View.Command
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract bool NeedsValidation { get; }
        protected abstract void Execute();

        public bool AttemptExecution()
        {
            try
            {
                Execute();
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