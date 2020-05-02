using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Command.Settings;

namespace SettlersOfValgard.View.Command
{
    public abstract class Command : INamed
    {
        public abstract string Name { get; }
        public abstract string [] Aliases { get; }
        public abstract List<Argument.Argument> Arguments { get; }
        public abstract List<Argument.Argument> OptionalArguments { get; }
        public abstract List<Tag> Tags { get; }
        public List<Tag> UsedTags = new List<Tag>();
        public abstract string UseCommandTo { get; }
        public virtual bool NeedsValidation => false;
        public virtual bool NeedsGodMode => false;

        public string Format
        {
            get
            {
                StringBuilder sb = new StringBuilder(Name);
                Arguments.ForEach(arg => sb.Append($" [{arg.Name}]"));
                OptionalArguments.ForEach(arg => sb.Append($" ({arg.Name})"));
                Tags.ForEach(tag => sb.Append($"({tag.Format})"));
                return sb.ToString();
            }
        }

        public string Input
        {
            get
            {
                StringBuilder sb = new StringBuilder(Name);
                Arguments.ForEach(arg => sb.Append($" {arg.Contents}"));
                foreach (var arg in OptionalArguments.Where(arg => arg.IsUsable()))
                {
                    sb.Append($" {arg.Contents}");
                }

                foreach (var tag in Tags.Where(tag => tag.Used))
                {
                    sb.Append($" {tag.Name}");
                    tag.Arguments.ForEach(arg => sb.Append($" {arg.Contents}"));
                }

                return sb.ToString();
            }
        }

        public void AttemptExecution(string [] args, Game game)
        {
            try
            {
                ProcessArguments(args);
                ValidateArguments();

                if (NeedsGodMode && !game.IsGodMode)
                {
                    throw new FormatException($"The command \"{Name}\" requires {Game.GodModeString}! (Use {new GodModeCommand().Aliases[0]} to enable {Game.GodModeString})");
                }

                if (NeedsValidation)
                {
                    if (!IOManager.GetYesNo($"Run command \"{Input}\"?"))
                    {
                        CustomConsole.WriteLine($"Aborted command {Name}");
                        return;
                    }
                }
                
                Execute(game);
            }
            catch (FormatException f)
            {
                CustomConsole.WriteLine(f.Message);
                CustomConsole.WriteLine($"{CustomConsole.Red}Format of \"{Name}\" is: \"{Format}\"");
            }
            catch (IndexOutOfRangeException e)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: format of \"{Name}\" is: \"{Format}\"");
            }

            Clear();
        }

        public void ValidateArguments()
        {
            foreach (var tag in UsedTags)
            {
                foreach (var arg in tag.Arguments)
                {
                    ValidateArgument(arg);
                }
            }
            
            foreach (var arg in Arguments)
            {
                ValidateArgument(arg);
            }

            foreach (var arg in OptionalArguments)
            {
                ValidateArgument(arg, false);
            }
        }

        public void ValidateArgument(Argument argument, bool required = true)
        {
            if(argument == null)
            {
                if (required)
                {
                    throw new FormatException($"{CustomConsole.Red}ERROR: Argument \"[{argument.Name}]\" is required!");
                }
            }
            else
            {
                if (!argument.IsUsable())
                {
                    if (argument is NaturalArgument)
                    {
                        throw new FormatException($"{CustomConsole.Red}ERROR: Argument \"[{argument.Name}]\" requires a positive interger input!");
                    }
                }
            }
        }

        public abstract void Execute(Game game);

        public void Clear()
        {
            Arguments.ForEach(arg => arg.Clear());
            Tags.ForEach(tag => tag.Clear());
            UsedTags = new List<Tag>();
        }

        public void ProcessArguments(string[] args)
        {
            
            var argCount = 0;
            
            for (var i = 0; i < args.Length; i++)
            {
                var tag = Tags.FirstOrDefault(tag => tag.Name == args[i]);
                if (tag != null && !UsedTags.Contains(tag))
                {
                    UsedTags.Add(tag);
                    if (i + tag.Arguments.Count >= args.Length)
                    {
                        throw new FormatException($"{CustomConsole.Red}ERROR: format of \"{tag.Name}\" is: \"{tag.Format}\"");
                    }
                    
                    var j = i + 1;
                    
                    foreach (var tagArg in tag.Arguments)
                    {
                        tagArg.Contents = args[j];
                        j++;
                    }

                    i = j;
                    continue;
                }

                if (argCount < Arguments.Count)
                {
                    Arguments[argCount].Contents = args[i];
                }
                else
                {
                    OptionalArguments[argCount - Arguments.Count].Contents = args[i];
                }
                
                argCount++;
            }
        }
    }
}