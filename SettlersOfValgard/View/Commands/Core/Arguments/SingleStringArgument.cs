﻿namespace SettlersOfValgard.View.Commands.Core.Arguments
{
    public class SingleStringArgument : StringArgument
    {

        public override void ProcessArgs(string[] args)
        {
            if (args.Length != 1)
            {
                throw new InputArgumentException($"The Argument {Name} is limited to 1 string!");
            }
            else
            {
                Contents = args[0];
            }
        }

        public SingleStringArgument(string name, string description) : base(name, description)
        {
        }
    }
}