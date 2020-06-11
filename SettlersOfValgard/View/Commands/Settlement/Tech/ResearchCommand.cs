using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.Settlement.Tech
{
    public class ResearchCommand : Command
    {
        public override string Name => "Research";
        public override string[] Aliases { get; } = {"res", "research", "Research"};
        public override string UseCommandTo => "select a technology to research.";
        public UnlimitedStringArgument TechNameArgument = new UnlimitedStringArgument("Tech Name", "The name of the technology to research.");
        public override List<Argument> OptionalArguments => new List<Argument>{TechNameArgument};

        public override void Execute(Game game)
        {
            var name = TechNameArgument.IsFilled ? TechNameArgument.Contents : "";
            var list = game.Settlement.TechManager.GetAvailableTech(game.Settlement)
                .Where(tech => StringsUtil.IsMatchingStartIgnoreCase(tech, name)).ToList();
            if (list.Count == 0)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: No technology with name starting with \"{name}\" found!");
            } 
            else if (list.Count == 1)
            {
                var tech = list[0];
                game.Settlement.TechManager.CurrentResearch = tech;
                CustomConsole.WriteLine($"Switched research to {tech} {tech.Progress}/{tech.Cost} ({MathUtil.RoundUp((tech.Cost - tech.Progress) / (double) game.Settlement.ResearchRate)} days)");
            }
            else
            {
                if (name != "")
                {
                    CustomConsole.WriteLine($"Technologies starting with \"{name}\"");
                }
                else
                {
                    CustomConsole.WriteLine("Available Technologies:");
                }
                IOManager.ListInConsole(list);
            }
        }
    }
}