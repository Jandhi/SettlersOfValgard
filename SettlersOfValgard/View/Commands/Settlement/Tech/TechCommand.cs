using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.Settlement.Tech
{
    public class TechCommand : Command
    {
        public override string Name => "Tech Command";
        public override string[] Aliases { get; } = {"tech", "technology", "Tech"};
        public override string UseCommandTo => "determine what technology to research.";
        public UnlimitedStringArgument TechNameArgument = new UnlimitedStringArgument("Tech Name", "The name of the technology");
        public override List<Argument> OptionalArguments => new List<Argument>{TechNameArgument};
        
        public readonly Tag DiscoveredTag = new Tag("-d", "display tech you have discovered.");

        public TechCommand()
        {
            Tags = new List<Tag>{DiscoveredTag};
        }

        public override List<Tag> Tags { get; }

        public override void Execute(Game game)
        {
            var rate = game.Settlement.ResearchRate;
            
            if (TechNameArgument.IsFilled)
            {
                var name = TechNameArgument.Contents;
                var techs = game.Settlement.TechManager.Tree.Technologies
                    .Where(tech => StringsUtil.IsMatchingStartIgnoreCase(tech, name)).ToList();
                if (techs.Count == 0)
                {
                    CustomConsole.WriteLine($"{CustomConsole.Red}No techs with name starting with \"{name}\"");
                } 
                else if (techs.Count > 1)
                {
                    foreach (var tech in techs)
                    {
                        CustomConsole.WriteLine($"{tech}");
                    }
                } 
                else
                {
                    var tech = techs[0];
                    CustomConsole.TitleLine();
                    CustomConsole.WriteLine($"{tech.Name.ToUpper()}:");
                    CustomConsole.WriteLine($"{tech.Description}");
                    if (game.Settlement.TechManager.Discovered.Contains(tech))
                    {
                        CustomConsole.WriteLine("[Discovered]");
                    } 
                    else if (game.Settlement.TechManager.GetAvailableTech(game.Settlement).Contains(tech))
                    {
                        CustomConsole.WriteLine($"Progress: {tech.Progress}/{tech.Cost} ({MathUtil.RoundUp((tech.Cost - tech.Progress) / (double) rate)} days)");
                    }
                    else
                    {
                        var list = new List<string>(tech.TechRequirements.Select(t => t.ToString()));
                        if (game.Settlement.Rank < tech.RankRequirement)
                        {
                            list.Add($"Player Rank {tech.RankRequirement}");
                        }
                        CustomConsole.WriteLine($"Requires: {StringsUtil.CommaList(list.ToArray())}");
                    }    
                }
            }
            else
            {
                var currentTech = game.Settlement.TechManager.CurrentResearch;
                var available = game.Settlement.TechManager.GetAvailableTech(game.Settlement);
                var discovered = game.Settlement.TechManager.Discovered;
                
                if (currentTech == null)
                {
                    CustomConsole.WriteLine($"{CustomConsole.Red}Not currently researching any tech.");
                }
                else
                {
                    CustomConsole.TitleLine();
                    CustomConsole.WriteLine($"Currently researching {currentTech}");
                    CustomConsole.WriteLine($"Progress: {currentTech.Progress}/{currentTech.Cost} ({MathUtil.RoundUp((currentTech.Cost - currentTech.Progress) / (double) rate)} days)");
                }
                
                CustomConsole.TitleLine();

                if (!DiscoveredTag.Used && available.Count > 0)
                {
                    CustomConsole.WriteLine("Available techs:");
                }
                else if (DiscoveredTag.Used && discovered.Count > 0)
                {
                    CustomConsole.WriteLine("Discovered techs:");
                }
                else if(!DiscoveredTag.Used)
                {
                    CustomConsole.WriteLine("No available techs!");
                }
                else
                {
                    CustomConsole.WriteLine("No discovered techs!");
                }

                if (!DiscoveredTag.Used)
                {
                    foreach (var tech in available)
                    {
                        CustomConsole.WriteLine($"{tech}: {tech.Progress}/{tech.Cost} ({MathUtil.RoundUp((tech.Cost - tech.Progress) / (double) rate)} days)");
                    }
                }
                else
                {
                    foreach (var tech in discovered)
                    {
                        CustomConsole.WriteLine($"{tech}");
                    }
                }
                
            }
        }
    }
}