using System;
using System.Linq;
using System.Text;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    
    public class ConstructCommand : Command
    {
        public override string Name => "Construct";
        public override string[] Aliases { get; } = {"c", "construct", "Construct"};
        public override bool AvailableInMenu => false;
        public override string ToolTip => $"Use \"{Aliases[0]}\" to Construct a building from Blueprint";

        protected override void Execute(string[] args, Game game)
        {
            if (args.Length == 0)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}You must choose a blueprint to construct. Use \"bp\" to list blueprints.{CustomConsole.White}");
            }
            else
            {
                var stringBuilder = new StringBuilder(args[0]);
                var count = 1;
                for (int i = 1; i < args.Length; i++)
                {
                    try
                    {
                        count = int.Parse(args[i]);
                    }
                    catch (FormatException e)
                    {
                        stringBuilder.Append($" {args[i]}");
                    }
                }
                var name = stringBuilder.ToString();
                var blueprint = game.Settlement.Blueprints.FirstOrDefault(bp => string.Equals(bp.Name, name, StringComparison.CurrentCultureIgnoreCase));
                
                if (blueprint == null)
                {
                    CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: No blueprint with name \"{name}\" found!");
                }
                else
                {
                    var settlement = game.Settlement;
                    var buildingName = count == 1 ? $"a {blueprint.Name}" : $"{blueprint.Name} x{count}";
                    
                    if (settlement.Stockpile.Contains(count * blueprint.Cost))
                    {
                        if (IOManager.GetYesNo($"Construct {buildingName}? Cost: {count * blueprint.Cost}"))
                        {
                            settlement.Stockpile.Remove(count * blueprint.Cost);
                            for(var i = 0; i < count; i++) settlement.Buildings.Add(blueprint.Building.Construct());
                            CustomConsole.WriteLine($"Built {buildingName}. Cost: {count * blueprint.Cost}");
                        }
                    }
                    else
                    {
                        CustomConsole.WriteLine($"{CustomConsole.Red}You do not have the resources to build {buildingName}!{CustomConsole.White} Cost: {count * blueprint.Cost}");
                    }
                    
                }
            }
        }
    }
}