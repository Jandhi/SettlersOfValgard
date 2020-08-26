using System.Collections.Generic;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Interface.Console.List;

namespace SettlersOfValgard.Interface.Commands.Settlement
{
    public class RegionCommand : ListOrDescribeCommand<Region>
    {
        public override string Name => "Region";
        public override string[] Aliases => new[] {"reg"};
        public override List<Region> List(Game.Game game)
        {
            return game.Settlement.Regions;
        }

        public override void Describe(Region item)
        {
            new Title<Region>(item).Write();
            VConsole.WriteLine($"{item.Description}");
            VConsole.WriteLine("Resources/Day:");
            new TextList<KeyValuePair<Resource, int>>(item.ResourceLimits,
                new TextListFormat<KeyValuePair<Resource, int>> {Func = pair => $"{pair.Key} x{pair.Value}", Indent = 1}, false).Write();
            
            VConsole.WriteLine($"Buildings:");
            foreach (var building in item.Buildings)
            {
                VConsole.WriteLine($" {building}");
            }
        }
 
        public override string TypeName => "region";
    }
}