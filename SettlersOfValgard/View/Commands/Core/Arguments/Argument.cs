using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.View.Commands.Core.Arguments
{
    public abstract class Argument : INamed
    {
        public string Name { get; }
        public abstract bool IsFilled { get; }
        public abstract string ContentsAsString { get; }


        protected Argument(string name)
        {
            Name = name;
        }

        public abstract void ProcessArgs(string[] args);
        public abstract void Clear();
    }
}