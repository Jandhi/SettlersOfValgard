using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.Settlement.Building
{
    public class ConstructCommand : Command
    {
        public override string Name => "Construct";
        public override string[] Aliases { get; } = {"c", "con", "construct"};
        public override string UseCommandTo => "construct a given blueprint.";
        public override List<Argument> Arguments => new List<Argument>{BlueprintNameArgument};
        public UnlimitedStringArgument BlueprintNameArgument = new UnlimitedStringArgument("Blueprint Name", "The name of the blueprint to construct.");
        public override List<Argument> OptionalArguments => new List<Argument>{NumberArgument};
        public NaturalNumberArgument NumberArgument = new NaturalNumberArgument("Number", "The Number of buildings to construct from blueprint");
        public override void Execute(Game game)
        {
            var blueprints =
                game.Settlement.Blueprints.Where(bp => StringsUtil.IsMatchingStartIgnoreCase(bp, BlueprintNameArgument.Contents)).ToList();
            if (blueprints.Count == 0)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: No blueprints with name starting with {BlueprintNameArgument.Contents} found!");
            } 
            else if (blueprints.Count == 1)
            {
                Construct(game.Settlement, blueprints[0]);
            }
            else
            {
                CustomConsole.WriteLine($"Choose a blueprint to construct:");
                IOManager.ListInConsole(blueprints);
            }
        }

        private void Construct(Model.Settlement.Settlement settlement, Blueprint blueprint)
        {
            var number = NumberArgument.IsFilled ? NumberArgument.Contents : 1;
            if (settlement.Stockpile.Contains(blueprint.Cost * number))
            {
                if (IOManager.GetYesNo(
                    $"Build {(number > 1 ? number.ToString() : "a")} {blueprint.Name}{(number > 1 ? "s" : "")}? Cost: {blueprint.Cost * number}"))
                {
                    for(int i = 0; i < number; i++) settlement.Buildings.Add(blueprint.Building.Construct());
                    settlement.Stockpile.Remove(blueprint.Cost * number);
                    CustomConsole.WriteLine($"{CustomConsole.Green}Constructed {(number > 1 ? number.ToString() : "a")} {blueprint.Name}{(number > 1 ? "s" : "")}! {blueprint.Cost.ToTransaction() * -1 * number}");
                }
            }
            else
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: You do not have the resources to construct {(number > 1 ? number.ToString() : "a")} {blueprint.Name}{(number > 1 ? "s" : "")}! {CustomConsole.White}{blueprint.Cost}");
            }
        }
    }
}