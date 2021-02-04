using System;
using System.Collections.Generic;
using SettlersOfValgard.Interface.Commands.Arguments;

namespace SettlersOfValgard.Interface.Commands
{
    public class Tag : Function
    {
        public override string Name { get; }
        public string UseTagTo { get; }
        public override string FunctionType => "Tag";
        public override List<Argument> Arguments { get; } = new List<Argument>();
        public override List<Argument> OptionalArguments { get; } = new List<Argument>();
        public bool Used { get; set; }


        public Tag(string name, string useTagTo, List<Argument> arguments = null, List<Argument> optionalArguments = null)
        {
            Name = name;
            UseTagTo = useTagTo;
            if(arguments != null) Arguments = arguments;
            if(optionalArguments != null) OptionalArguments = optionalArguments;

            if (!name.StartsWith("-"))
            {
                throw new FormatException($"The Tag {Name} does not begin with '-'");
            }
        }

        public override void ProcessArgs(string[] args)
        {
            try
            {
                base.ProcessArgs(args);
                Used = true;
            }
            catch (Exception e)
            {
                throw new InputArgumentException(e.Message);
            }
        }

        public override void Clear()
        {
            Used = false;
            base.Clear();
        }
    }
}