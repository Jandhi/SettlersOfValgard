using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.Settlement.Settler
{
    public class RelationshipCommand : Command
    {
        public override string Name => "Relationships";
        public override string[] Aliases { get; } = {"rel"};
        public override string UseCommandTo => "list a settler's relationship";
        public override List<Argument> Arguments => new List<Argument>{SettlerNameArgument};
        public UnlimitedStringArgument SettlerNameArgument = new UnlimitedStringArgument("Settler Name", "the name of the settler whose relationships to list");
        public override List<Tag> Tags { get; }
        public Tag AllTag = new Tag("-all", "display relationships for all settlers with name");

        public RelationshipCommand()
        {
            Tags = new List<Tag>{AllTag};
        }

        public override void Execute(Game game)
        {
            var settlers = game.Settlement.Settlers.Where(settler =>
                StringsUtil.IsMatchingStartIgnoreCase(settler, SettlerNameArgument.Contents)).ToList();

            if (settlers.Count == 0)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: No settlers with name starting with \"{SettlerNameArgument.Contents}\" found");
            }
            else if (settlers.Count > 1)
            {
                if (AllTag.Used)
                {
                    foreach (var settler in settlers)
                    {
                        ListRelationships(settler);
                    }
                }
                else
                {
                    CustomConsole.WriteLine($"Settlers with name starting with \"{SettlerNameArgument.Contents}\":");
                    IOManager.ListInConsole(settlers);
                }
            }
            else if (settlers.Count == 1)
            {
                ListRelationships(settlers[0]);
            }
        }

        private static void ListRelationships(Model.Settler.Settler settler)
        {
            CustomConsole.TitleLine();
            CustomConsole.WriteLine($"{settler}'s Relationships:");
            foreach (var relationship in settler.Relationships)
            {
                var other = relationship.Other(settler);
                CustomConsole.WriteLine($"{relationship.Role(other)}: {other} [{relationship.Level}]");
            }
        }
    }
}