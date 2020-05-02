using System.Collections.Generic;
using System.Linq;
using System.Text;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.Core
{
    public abstract class Command : Function
    {
        public virtual List<Tag> Tags { get; } = new List<Tag>();
        public abstract string[] Aliases { get; }

        public override string FunctionType => "Commmand";

        public void AttemptExecution(string[] args, Game game)
        {
            ProcessArgs(args);
            Execute(game);
            Clear();
        }

        public override void ProcessArgs(string[] args)
        {
            Tag tag = null;
            var tagsUsed = new List<Tag>();
            var startIndex = 0;
            for (int i = 0; i < args.Length; i++)
            {
                if (Tags.Where(tag => !tagsUsed.Contains(tag)).Any(tag => tag.Name == args[i]))
                {
                    if (tag == null)
                    {
                        base.ProcessArgs(ArraysUtility.SubArray(args, startIndex, i - startIndex));
                    }
                    else
                    {
                        tag.ProcessArgs(ArraysUtility.SubArray(args, startIndex, i - startIndex));
                        tagsUsed.Add(tag);
                    }

                    tag = Tags.FirstOrDefault(tag => tag.Name == args[i]);
                    startIndex = i + 1;
                }
            }
            
            if (tag == null)
            {
                base.ProcessArgs(ArraysUtility.SubArray(args, startIndex, args.Length - startIndex));
            }
            else
            {
                tag.ProcessArgs(ArraysUtility.SubArray(args, startIndex, args.Length - startIndex));
                tagsUsed.Add(tag);
            }
        }

        public override void Clear()
        {
            base.Clear();
            Tags.ForEach(tag => tag.Clear());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            foreach (var VARIABLE in Tags.Where(tag => tag.Used))
            {
                Tags.ForEach(tag => sb.Append($" {tag}"));
            }
            return sb.ToString();
        }

        public abstract void Execute(Game game);
    }
}