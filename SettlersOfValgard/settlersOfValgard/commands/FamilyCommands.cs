using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.settlersOfValgard.buildings;
using SettlersOfValgardGame.settlersOfValgard.settlers;
using SettlersOfValgardGame.ui.commands;
using SettlersOfValgardGame.ui.commands.arguments;
using SettlersOfValgardGame.ui.commands.builder;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.elements;
using SettlersOfValgardGame.util;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.settlersOfValgard.commands
{
    public class FamilyCommands
    {
        
        public static SelectionCommandBuilding.Selection<Family> FamilySelection = new SelectionCommandBuilding.Selection<Family>();
        public static SelectionCommandBuilding.Selection<Residence> ResidenceSelection = new SelectionCommandBuilding.Selection<Residence>();
        public static readonly Command MoveCommand = new CommandBuilder()
            .WithName("Move")
            .WithDescription(Text("move a family to a residence of your choice."))
            .WithDefaultSelectionAction<SettlersOfValgard, Family>(
                (game, command) => game.Settlement.Families,
                FamilySelection, "family", "families")
            .WithDefaultSelectionAction<SettlersOfValgard, Residence>(
                (game, command) => game.Settlement.Buildings.Where(building => building is Residence).Cast<Residence>().ToList(),
                ResidenceSelection, "residence")
            .WithConditionalAction((game, command) => FamilySelection.Content != null && ResidenceSelection.Content != null,
                (game, command) =>
                {
                    //move family to residence
                })
            .Build();
        public static void DisplayFamily(Family family, SettlersOfValgard game, Command command)
        {
            Clear();
            game.AddElement(new TitleElement(family));
        }

        public static readonly Command FamilyCommand = new CommandBuilder()
            .WithName("Family")
            .WithDescription(Text("display information about your settlers"))
            .WithStandardListAction(
                (game, command) => game.Settlement.Families,
                ListCommands.CreateListOrDisplayAction<SettlersOfValgard, Family>("family", DisplayFamily, "families"))
            .Build();

        public static List<Command> Commands = new List<Command>{FamilyCommand, MoveCommand};
    }
}