using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.settlersOfValgard.resources;
using SettlersOfValgardGame.ui.commands;
using SettlersOfValgardGame.ui.commands.arguments;
using SettlersOfValgardGame.ui.commands.builder;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.elements;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.settlersOfValgard.commands
{
    public static class ResourceCommands
    {
        private static readonly Command StockpileCommand = new CommandBuilder()
            .WithName("Stockpile")
            .WithAction<SettlersOfValgard>((game, command) =>
            {

                if (game.Settlement.Stockpile.IsEmpty())
                {
                    WriteError("Your stockpile is empty!");
                }
                else
                {
                    game.AddElement(ListElement<VTextWrapper<(Resource, int)>>.CreateListElement(
                        game.Settlement.Stockpile
                            .Where((resource, amount) => amount > 0)
                            .Select(entry => new VTextWrapper<(Resource, int)>(entry, entry =>
                            {
                                var (resource, amount) = entry;
                                return resource + Text(" x" + amount);
                            })).ToList(), 
                        Text("Stockpile")));
                }
            })
            .Build();
        
        private static readonly SelectionCommandBuilding.Selection<Resource> AddResourceSelection = new SelectionCommandBuilding.Selection<Resource>();
        private static readonly IntegerArgument AddResourceAmount = new IntegerArgument("amount", Text("the amount of the resource you are adding"));

        private static readonly Command AddResourceCommand = new CommandBuilder()
            .WithName("AddResource")
            .WithRequiredPermissions(Permission.Debug)
            .WithDefaultSelectionAction<SettlersOfValgard, Resource>(
                (game, command) => Resource.AllResources,
                AddResourceSelection,
                "resource")
            .WithArguments(AddResourceAmount)
            .WithAction<SettlersOfValgard>((game, command) =>
            {
                var resource = AddResourceSelection.Content;
                var amount = AddResourceAmount.Content;
                game.Settlement.Stockpile.Add(resource, amount);
                WriteLine(Text("Added " + amount) + Text(" ") + resource);
            })
            .Build();
        
        public static List<Command> Commands = new List<Command>{StockpileCommand, AddResourceCommand};
    }
}