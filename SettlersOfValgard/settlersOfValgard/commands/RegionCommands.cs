using System.Collections.Generic;
using SettlersOfValgardGame.settlersOfValgard.regions;
using SettlersOfValgardGame.settlersOfValgard.terrain;
using SettlersOfValgardGame.ui.commands;
using SettlersOfValgardGame.ui.commands.builder;
using SettlersOfValgardGame.ui.elements;

namespace SettlersOfValgardGame.settlersOfValgard.commands
{
    public static class RegionCommands
    {
        public static void DisplayTerrain(Terrain terrain, SettlersOfValgard game, Command command)
        {
            game.AddElement(new TitleElement(terrain));
        }
        
        public static Command TerrainCommand = new CommandBuilder()
            .WithName("Terrains")
            .WithStandardListAction(
                (game, command) => game.Settlement.SelectedRegion.Terrains,
                ListCommands.CreateListOrDisplayAction<SettlersOfValgard, Terrain>("terrain", DisplayTerrain))
            .Build();
        
        public static List<Command> Commands = new List<Command>{TerrainCommand};
    }
}