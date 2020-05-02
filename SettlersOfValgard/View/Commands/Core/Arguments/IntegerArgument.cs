using System;

namespace SettlersOfValgard.View.Commands.Core.Arguments
{
    public class IntegerArgument : Argument
    {
        public int Contents { get; set; }
        protected bool IsValid = false;

        public IntegerArgument(string name) : base(name)
        {
        }

        public override bool IsFilled => IsValid;
        public override string ContentsAsString => Contents.ToString();
        public override void ProcessArgs(string[] args)
        {
            if (args.Length != 1)
            {
                throw new InputArgumentException($"The Argument {Name} is limited to 1 number!");
            }
            else
            {
                try
                {
                    Contents = int.Parse(args[0]);
                    IsValid = true;
                }
                catch (FormatException e)
                {
                    throw new InputArgumentException($"The Argument {Name} requires an integer value!");
                }
            }
        }

        public override void Clear()
        {
            IsValid = false;
        }
    }
}