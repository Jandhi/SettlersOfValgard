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
        public override string UseCommandTo => $"List {Type}s in your settlement, or display information about one.";
        
        public override List<Argument> OptionalArguments => new List<Argument>{NameArgument, NumberArgument};
        public UnlimitedStringArgument NameArgument = new UnlimitedStringArgument("Name", "The name of the item to display");
        public NaturalNumberArgument NumberArgument = new NaturalNumberArgument("Number", "The nth item to display");
        public override List<Tag> Tags => new List<Tag>(AdditionalTags){EndFilterTag, NumberedTag, SeparatedTag};
        public Tag EndFilterTag;
        public UnlimitedStringArgument NameEndArgument = new UnlimitedStringArgument("End", "The end of the name");
        public readonly Tag NumberedTag = new Tag("-n", "Number the listed items");
        public readonly Tag SeparatedTag = new Tag("-s", "Separate items with the same name");

        public ListOrDisplayCommand()
        {
            EndFilterTag = new Tag("-end", "Specify the end of the name", new List<Argument>{NameEndArgument});
        }

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
                        Display(list, game.Settlement.ToString());
                    }
                    else
                    {
                        Display(list[0]);
                    }
                }
            }
            else
            {
                var list = GetFilteredList(game);
                if (list.Count == 0)
                {
                    CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: No {Type}s found.");
                }
                else
                {
                    Display(list, game.Settlement.ToString());   
                }
            }
        }

        private void Display(List<T> list, string settlement)
        {
            CustomConsole.TitleLine();
            CustomConsole.WriteLine($"{StringsUtil.ToUpperIgnoreColor(Type)}S IN {StringsUtil.ToUpperIgnoreColor(settlement)}");
            IOManager.ListInConsole(list, NumberedTag.Used, SeparatedTag.Used);
        }

        private List<T> GetFilteredList(Game game)
        {
            List<T> list = GetList(game);
            
            if(NameArgument.IsFilled) {
                var length = NameArgument.Contents.Length;
                list = list.Where(item => item.Name.Length >= length && string.Equals(item.Name.Substring(0, length), NameArgument.Contents, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            
            if (EndFilterTag.Used)
            {
                var length = NameEndArgument.Contents.Length;
                list = list.Where(item => item.Name.Length >= length && string.Equals(item.Name.Substring(item.Name.Length - length, length), NameEndArgument.Contents, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            
            return list.Where(item => AdditionalFilter(item)).ToList();
        }

        public virtual bool AdditionalFilter(T item)
        {
            return true;
        }
        public abstract List<T> GetList(Game game);
        public abstract void Display(T t);
        public virtual List<Tag> AdditionalTags { get; } = new List<Tag>();
    }
}