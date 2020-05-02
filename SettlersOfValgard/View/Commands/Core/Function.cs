using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands
{
    //Class that takes in a number of arguments and processes them
    public abstract class Function : INamed
    {
        public abstract string Name { get; }
        public abstract string FunctionType { get; }
        public virtual List<Argument> Arguments { get; } = new List<Argument>();
        public virtual List<Argument> OptionalArguments { get; } = new List<Argument>();

        public string Format
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                Arguments.ForEach(arg => sb.Append($"[{arg.Name}] "));
                OptionalArguments.ForEach(arg => sb.Append($"({arg.Name}) "));
                if(sb.Length > 0) sb.Remove(sb.Length - 1, 1); // No extra space
                return sb.ToString();
            }
        }


        public Function()
        {
            if (Arguments.Count(arg => arg is UnlimitedStringArgument) + OptionalArguments.Count(arg => arg is UnlimitedStringArgument) > 1)
            {
                throw new FormatException($"The {FunctionType} {Name} has more than one unlimited argument! (limit: 1)");
            }
        }

        public virtual void ProcessArgs(string[] args)
        {
            if (args.Length < Arguments.Count)
            {
                throw new FormatException($"The {FunctionType} {Name} needs at least {Arguments.Count} arguments!");
            }
            
            if (Arguments.Any(arg => arg is UnlimitedStringArgument))
            {
                for (var i = args.Length - Arguments.Count; i > 0; i--)
                {
                    try
                    {
                        var arguments = new List<Argument>();
                        arguments.AddRange(Arguments);
                        arguments.AddRange(OptionalArguments.GetRange(0, i));
                        ProcessUnlimited(args, arguments);
                    }
                    catch(Exception e) { continue; }
                    
                    return;
                }
                
                ProcessUnlimited(args, Arguments);
            }
            else if(OptionalArguments.Any(arg => arg is UnlimitedStringArgument))
            {
                var optArgs = new string[args.Length - Arguments.Count];
                for (var i = 0; i < args.Length; i++)
                {
                    if (i < Arguments.Count)
                    {
                        Arguments[i].ProcessArgs(new []{args[i]});
                    }
                    else
                    {
                        optArgs[i - Arguments.Count] = args[i];
                    }
                }
                ProcessUnlimited(optArgs, OptionalArguments);
            }
            else
            {
                if (args.Length > Arguments.Count + OptionalArguments.Count)
                {
                    throw new FormatException($"The {FunctionType} {Name} can only take up to {Arguments.Count + OptionalArguments.Count} arguments!");
                }

                for (var i = 0; i < args.Length; i++)
                {
                    if (i < Arguments.Count)
                    {
                        Arguments[i].ProcessArgs(new []{args[i]});
                    }
                    else
                    {
                        OptionalArguments[i - Arguments.Count].ProcessArgs(new []{args[i]});
                    }
                }
            }
        }

        private void ProcessUnlimited(string[] args, List<Argument> arguments)
        {
            //Splits arguments before and after unlimited argument and gives unlimited argument the leftovers
            var before = new List<Argument>();
            UnlimitedStringArgument unlimitedArg = null;
            var after = new List<Argument>();

            bool hit = false;
            foreach (var arg in arguments)
            {
                if (arg is UnlimitedStringArgument unlimitedStringArgument)
                {
                    unlimitedArg = unlimitedStringArgument;
                    hit = true;
                } 
                else if (hit)
                {
                    after.Add(arg);
                }
                else
                {
                    before.Add(arg);
                }
            }
                
            for(var i = 0; i < before.Count; i++) before[i].ProcessArgs(new []{args[i]});
            var unlimitedArgs = new string[args.Length - after.Count - before.Count];
            for (var i = before.Count; i < args.Length - after.Count; i++)
                unlimitedArgs[i - before.Count] = args[i];
            if(unlimitedArgs.Length > 0) unlimitedArg.ProcessArgs(unlimitedArgs);
            for(var i = 0; i < after.Count; i++) after[i].ProcessArgs(new []{args[args.Length - after.Count + i]});
        }

        //Clears data from arguments

        public virtual void Clear()
        {
            Arguments.ForEach(arg => arg.Clear());
            OptionalArguments.ForEach(arg => arg.Clear());
        }

        public override string ToString()
        {
            var sb = new StringBuilder(Name);
            Arguments.ForEach(arg => sb.Append($" [{arg.Name}:{arg.ContentsAsString}]"));
            foreach (var arg in OptionalArguments.Where(arg => arg.IsFilled))
            {
                sb.Append($" ({arg.Name}:{arg.ContentsAsString})");
            }
            return sb.ToString();
        }
    }
}