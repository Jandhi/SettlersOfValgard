using System;
using System.Collections.Generic;
using SettlersOfValgard.Model.Settler.Gender;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.Settlement.Settler
{
    public class SettlerCommand : ListOrDisplayCommand<Model.Settler.Settler>
    {
        public override string Name => "Settler";
        public override string[] Aliases { get; } = {"s", "settler"};
        public override List<Tag> AdditionalTags => new List<Tag>{GenderTag};
        public Tag GenderTag;
        public UnlimitedStringArgument GenderArgument = new UnlimitedStringArgument("Gender", "Specify gender of settler");

        public SettlerCommand()
        {
            GenderTag = new Tag("-gen", "Determine gender of settlers selected.", new List<Argument>{GenderArgument});
        }

        public override string Type => "Settler";
        public override List<Model.Settler.Settler> GetList(Game game)
        {
            return game.Settlement.Settlers;
        }

        public override bool AdditionalFilter(Model.Settler.Settler item)
        {
            if (GenderTag.Used)
            {
                if (item is IGendered<BinaryGender> gendered)
                {
                    return StringsUtil.IsMatchingStartIgnoreCase(gendered.Gender, GenderArgument.Contents) 
                           || string.Equals(gendered.Gender.Symbol, GenderArgument.Contents, StringComparison.CurrentCultureIgnoreCase);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public override void Display(Model.Settler.Settler settler)
        {
            CustomConsole.WriteLine($"{StringsUtil.ToUpperIgnoreColor(settler.ToString())}:");
            CustomConsole.TitleLine();

            var traits = settler.MajorTraits();
            if(traits != "") CustomConsole.WriteLine($"{traits}");
            
            if (settler is IGendered<Gender> gendered)
            {
                CustomConsole.WriteLine($"Gender: {gendered.Gender}");
            }
            
            CustomConsole.WriteLine($"Prestige: {settler.PrestigeLevel}");
        }
    }
}