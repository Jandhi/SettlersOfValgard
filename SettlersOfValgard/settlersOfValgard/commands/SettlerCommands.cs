using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.settlersOfValgard.settlers;
using SettlersOfValgardGame.ui.commands;
using SettlersOfValgardGame.ui.commands.builder;
using SettlersOfValgardGame.ui.elements;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.settlersOfValgard.commands
{
    public static class SettlerCommands
    {
        public static void DisplaySettler(Settler settler, SettlersOfValgard game, Command command)
        {
            Console.Clear();
            game.AddElement(new TitleElement(settler));
        }

        public static readonly Command SettlerCommand = new CommandBuilder()
            .WithName("Settler")
            .WithDescription(Text("display information about your settlers"))
            .WithStandardListAction(
                (game, command) => game.Settlement.Settlers,
                ListCommands.CreateListOrDisplayAction<SettlersOfValgard, Settler>("command", DisplaySettler))
            .Build();

        public static List<Command> Commands = new List<Command>{SettlerCommand};
    }
}