using System.Collections.Generic;
using SettlersOfValgardGame.settlersOfValgard.commands;
using SettlersOfValgardGame.settlersOfValgard.content.buildings;
using SettlersOfValgardGame.settlersOfValgard.testing;
using SettlersOfValgardGame.ui.commands;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.environment;
using SettlersOfValgardGame.ui.player;
using static SettlersOfValgardGame.ui.console.VConsole;
using Command = SettlersOfValgardGame.ui.commands.Command;

namespace SettlersOfValgardGame.settlersOfValgard
{
    public class SettlersOfValgard : Game
    {
        public static List<Command> GetSettlersOfValgardCommands()
        {
            var list = new List<Command>();
            list.AddRange(SettlerCommands.Commands);
            list.AddRange(BuildingCommands.Commands);
            list.AddRange(FamilyCommands.Commands);
            list.AddRange(ResourceCommands.Commands);
            return list;
        }
        public Settlement Settlement { get; }
        public World World { get; }

        private static void OnStartAction(Game game)
        {
            WriteLine(Text("Welcome to "), Text("Settlers of Valgard", VColor.Sky));
        }

        private static void OnCloseAction(Game game)
        {
            WriteLine("Bye!");
        }
        
        public SettlersOfValgard(Profile profile) : base(profile, 13, GetSettlersOfValgardCommands(), OnStartAction, OnCloseAction)
        {
            World = new TestWorld();
            Settlement = new TestSettlement();
        }
    }
}