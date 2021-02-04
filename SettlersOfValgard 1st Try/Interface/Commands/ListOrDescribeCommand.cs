using System.Collections.Generic;
using SettlersOfValgard.Interface.Commands.Arguments;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Interface.Console.List;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Interface.Commands
{
    public abstract class ListOrDescribeCommand<T> : Command where T : INamed
    {
        public abstract List<T> List(Game.Game game);
        public abstract void Describe(T item);
        public abstract string TypeName { get; }
        public override string UseCommandTo => $"Get details about your settlement's {TypeName}s"; 

        public StringArgument NameArgument;

        public StringArgument SuffixArgument;
        public Tag SuffixTag;
        public StringArgument ContainsArgument;
        public Tag ContainsTag;
        public Tag NumberedTag;
        public Tag SeparatedTag;

        public ListOrDescribeCommand()
        {
            NameArgument = new StringArgument("name", $"The start of the name of the {TypeName}");
            SuffixArgument = new StringArgument("suffix", $"The end of the name of the {TypeName}");
            SuffixTag = new Tag("-end", "look for items with a specific suffix", new List<Argument> {SuffixArgument});
            ContainsArgument = new StringArgument("contained", $"The string contained within the name of the {TypeName}");
            ContainsTag = new Tag("-con", "look for items containing a specific string", new List<Argument>{ContainsArgument});
            NumberedTag = new Tag("-n", "number the items listed");
            SeparatedTag = new Tag("-s", "list items of the same name separately");
        }

        public override List<Argument> OptionalArguments => new List<Argument>{NameArgument};
        public override List<Tag> Tags => new List<Tag>{SuffixTag, ContainsTag, NumberedTag, SeparatedTag};

        public override void Execute(Game.Game game)
        {
            var suffix = SuffixTag.Used ? SuffixArgument.Contents : null;
            var contains = ContainsTag.Used ? ContainsArgument.Contents : null;
            var list = StringsUtility.Match(NameArgument.IsFilled ? NameArgument.Contents : "", List(game), suffix, contains);
            if (list.Count == 0)
            {
                VConsole.WriteLine($"No {TypeName} found!");
            } 
            else if (list.Count > 1)
            {
                var format = new TextListFormat<T>
                {
                    Func = item => item.Name, IsNumbered = NumberedTag.Used, IsGrouped = !SeparatedTag.Used
                };
                new TextList<T>(list, format).Write();
            }
            else
            {
                Describe(list[0]);
            }
        }
    }
}