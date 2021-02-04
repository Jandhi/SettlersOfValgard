using System.Collections.Generic;
using SettlersOfValgard.Game.Buildings;
using SettlersOfValgard.Game.Regions;
using SettlersOfValgard.Game.Regions.Features;
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
            if(item.Features.Count != 0) VConsole.WriteLine("Features:");
            new TextList<Feature>(item.Features,
                new TextListFormat<Feature> {Func = ft => $"{ft}", Indent = 1}, false).Write();
            
            if(item.Buildings.Count != 0) VConsole.WriteLine($"Buildings:");
            new TextList<Building>(item.Buildings,
                new TextListFormat<Building>{Func = bd => $"{bd}", Indent = 1}, false).Write();
        }
 
        public override string TypeName => "region";
    }
}