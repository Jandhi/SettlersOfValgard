using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.Core
{
    public abstract class ListOrDisplayCommand<T> : Command where T : INamed
    {
        public abstract string Type { get; }
        
        public override List<Argument> OptionalArguments => new List<Argument>{NameArgument, NumberArgument};
        public UnlimitedStringArgument NameArgument = new UnlimitedStringArgument("Name", "The name of the item to display");
        public NaturalNumberArgument NumberArgument = new NaturalNumberArgument("Number", "The nth item to display");
        public override List<Tag> Tags => new List<Tag>{NumberedTag, SeparatedTag};
        public readonly Tag NumberedTag = new Tag("-n", "Number the listed items");
        public readonly Tag SeparatedTag = new Tag("-s", "Separate items with the same name");

        public override void Execute(Game game)
        {
            if (NameArgument.IsFilled)
            {
                if (NumberArgument.IsFilled)
                {
                    var list = GetFilteredList(game);
                    if (list.Count < NumberArgument.Contents)
                    {
                        CustomConsole.WriteLine(
                            $"{CustomConsole.Red}ERROR: There are only {list.Count} items with name starting with {NameArgument.Contents}!");
                    }
                    else
                    {
                        Display(list[NumberArgument.Contents - 1]);
                    }
                }
                else
                {
                    var list = GetFilteredList(game);
                    
                    
                    if (list.Count == 0)
                    {
                        CustomConsole.WriteLine(
                            $"{CustomConsole.Red}ERROR: No {Type} with name starting with {NameArgument.Contents} found!");
                    }
                    else if (list.Count > 1)
                    {
                        Display(list);
                    }
                    else
                    {
                        Display(list[0]);
                    }
                }
            }
            else
            {
                Display(GetList(game));
            }
        }

        private void Display(List<T> list)
        {
            IOManager.ListInConsole(list, NumberedTag.Used, SeparatedTag.Used);
        }

        private List<T> GetFilteredList(Game game)
        {
            var length = NameArgument.Contents.Length;
            return GetList(game).Where(item => item.Name.Length >= length && string.Equals(item.Name.Substring(0, length), NameArgument.Contents, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
        public abstract List<T> GetList(Game game);
        public abstract void Display(T t);
    }
}