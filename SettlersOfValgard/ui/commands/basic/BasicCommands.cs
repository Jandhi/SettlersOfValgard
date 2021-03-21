using System;
using System.Collections.Generic;
using SettlersOfValgardGame.ui.commands.arguments;
using SettlersOfValgardGame.ui.commands.builder;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.elements;
using SettlersOfValgardGame.ui.environment;
using SettlersOfValgardGame.util.random;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.commands.basic
{
    public static class BasicCommands
    {
        public static List<Command> Commands => new List<Command>{_quit, _debug, _back, _colors, _commands, _setSeed, _getSeed, _random};

        private static Command _quit = new CommandBuilder()
            .WithName("Quit")
            .WithDescription(Text("quit the game"))
            .WithYesNoAction((game, command) =>
            {
                foreach (var loop in game.InputLoops)
                {
                    loop.IsLooping = false;
                }
            })
            .Build();
        
        private static Command _back = new CommandBuilder()
            .WithName("Back")
            .WithDescription(Text("return to previous options"))
            .WithAction((game, command) =>
            {
                if(game.InputLoops.Count == 1) throw new GameException("You can't go further back!");

                foreach (var loop in game.InputLoops)
                {
                    loop.IsLooping = false;
                }

                game.InputLoops[0].IsLooping = true;
            })
            .Build();

        private static Command _debug = new CommandBuilder()
            .WithName("Debug")
            .WithDescription(Text("toggle ") + Permission.Debug + Text(" permission"))
            .WithAction((game, command) =>
            {
                if (game.Profile.Permissions.Contains(Permission.Debug))
                {
                    game.Profile.Permissions.Remove(Permission.Debug);
                    WriteLine(Permission.Debug + Text(" mode disabled"));
                }
                else
                {
                    game.Profile.Permissions.Add(Permission.Debug);
                    WriteLine(Permission.Debug + Text(" mode enabled"));
                }
            })
            .Build();

        private static Command _colors = new CommandBuilder()
            .WithName("Colors")
            .WithDescription(Text("show all the console colors"))
            .WithAction((game, command) =>
            {
                game.AddElement(new MultiPageListElement<VColor>(VColor.Colors, 10));
            })
            .Build();

        private static Command _commands = new CommandBuilder()
            .WithName("Commands")
            .WithDescription(Text("show all available commands"))
            .WithStandardListAction(
            (game, command) => game.InputLoops[^1].Commands,
            ListCommands.CreateListAction<Game, Command>("command"))
            .Build();
        
        private static IntegerArgument _seedArgument = new IntegerArgument("Seed", Text("The value of your ") + Text("seed", ColorStandards.Seed));
        private static Command _setSeed = new CommandBuilder()
            .WithName("SetSeed")
            .WithArguments(_seedArgument)
            .WithAction((game, command) =>
            {
                game.Seed = Convert.ToUInt32( _seedArgument.Content);
                WriteLine(Text("Set ") + Text("seed", ColorStandards.Seed) + Text(" to ") + Text(_seedArgument.Content.ToString(), ColorStandards.Value));
            })
            .Build();
        
        private static Command _getSeed = new CommandBuilder()
            .WithName("GetSeed")
            .WithAction((game, command) =>
            {
                if (game.SeedIsSet)
                {
                    WriteLine(Text("Your ") + Text("seed", ColorStandards.Seed) + Text(" is ") + Text(game.Seed.ToString(), ColorStandards.Value));
                }
                else
                {
                    WriteError(Text("Your ") + Text("seed", ColorStandards.Seed) + Text(" has not been set"));
                }
            })
            .Build();
        
        private static IntegerArgument _positionArgument = new IntegerArgument("position", Text("position for which to generate noise"));
        private static IntegerArgument _boundArgument = new IntegerArgument("bound", Text("the bound n such that output is 0 <= x < n"));
        private static Command _random = new CommandBuilder()
            .WithName("Random")
            .WithArguments(_positionArgument)
            .WithOptionalArguments(_boundArgument)
            .WithAction((game, command) =>
            {
                if (!game.SeedIsSet)
                {
                    throw new GameException("seed not set");
                }
                
                var value = Noise.GetNoise(_positionArgument.Content, game.Seed);
                if (_boundArgument.IsFilled())
                {
                    value %= Convert.ToUInt32(_boundArgument.Content);
                }
                WriteLine(Text(value.ToString(), ColorStandards.Value));
            })
            .Build();
    }
}