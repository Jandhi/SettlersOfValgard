using System;
using System.Collections.Generic;
using SettlersOfValgardGame.settlersOfValgard.buildings;
using SettlersOfValgardGame.ui.commands;
using SettlersOfValgardGame.ui.commands.builder;
using SettlersOfValgardGame.ui.elements;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.settlersOfValgard.commands
{
    public static class BuildingCommands
    {
        public static void DisplayBuilding(Building building, SettlersOfValgard game, Command command)
        {
            Clear();
            game.AddElement(new TitleElement(building));
        }

        public static readonly Command BuildingCommand = new CommandBuilder()
            .WithName("Building")
            .WithDescription(Text("display information about your settlers"))
            .WithStandardListAction(
                (game, command) => game.Settlement.Buildings,
                ListCommands.CreateListOrDisplayAction<SettlersOfValgard, Building>("building", DisplayBuilding))
            .Build();

        public static List<Command> Commands = new List<Command>{BuildingCommand};
    }
}