using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.View.Commands.Core.Arguments
{
    public abstract class Argument : INamed, IDescribed
    {
        public string Name { get; }
        public string Description { get; }
        public abstract string Type { get; }
        public abstract bool IsFilled { get; }
        public abstract string ContentsAsString { get; }


        protected Argument(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public abstract void ProcessArgs(string[] args);
        public abstract void Clear();
    }
}