using System;
using System.Linq;
using System.Text;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settler
{
    public class RelationshipCommand : Command
    {
        public override string Name => "Relationships";

        public override string[] Aliases { get; } =
            {"rel", "Rel", "relationships", "Relationships", "relationship", "Relationships"};

        public override string ToolTip => $"Use \"{Aliases[0]} [name]\" to list the relationships of the settler named [name]";
        protected override void Execute(string[] args, Game game)
        {
            if (args.Length == 0)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: {ToolTip}");
                return;
            }
            
            StringBuilder sb = new StringBuilder(args[0]);
            for (int i = 1; i < args.Length; i++) sb.Append($" {args[i]}");
            var name = sb.ToString();

            var settler = game.Settlement.Settlers.FirstOrDefault(s =>
                string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
            if (settler == null)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}No settler with name {name} found!");
            }
            else
            {
                CustomConsole.WriteLine($"{settler.Name}'s Relationships:");
                CustomConsole.VerticalLine();
                foreach (var relationship in settler.Relationships)
                {
                    var otherSettler = relationship.Other(settler);
                    var otherRole = relationship.Role(otherSettler);
                    CustomConsole.WriteLine($"{otherRole}: {otherSettler} [{relationship.Level}]");
                }
            }
        }
    }
}