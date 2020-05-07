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
                    var list = GetList(game).Where(t =>
                            string.Equals(t.Name, NameArgument.Contents, StringComparison.CurrentCultureIgnoreCase))
                        .ToList();
                    if(list.Count < NumberArgument.Contents) 
                    {
                        CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: There are only {list.Count} items with name {NameArgument.Contents}!");
                    } 
                    else
                    {
                        Display(list[NumberArgument.Contents - 1]);
                    }
                }
                else
                {
                    var item = GetList(game).FirstOrDefault(t => string.Equals(t.Name, NameArgument.Contents, StringComparison.CurrentCultureIgnoreCase));
                    if (item == null)
                    {
                        CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: No {Type} with name {NameArgument.Contents} found!");
                    }
                    else
                    {    
                        Display(item);
                    }
                }
            }
            else
            {
                IOManager.ListInConsole(GetList(game), NumberedTag.Used, SeparatedTag.Used);
            }
        }
        
        public abstract List<T> GetList(Game game);
        public abstract void Display(T t);
    }
}