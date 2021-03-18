using System;
using System.Collections.Generic;
using SettlersOfValgardGame.ui.commands;
using SettlersOfValgardGame.ui.commands.builder;
using SettlersOfValgardGame.ui.console.text;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.environment
{
    public class YesNoLoop : InputLoop
    {
        private static readonly Command YesCommand = new CommandBuilder()
            .WithName("yes")
            .WithDescription(Text("confirm your choice"))
            .WithAction((game, command) =>
            {
                var loop = game.InputLoops[^1] as YesNoLoop;
                loop.Response = true;
                loop.IsLooping = false;
            })
            .Build();

        private static readonly Command NoCommand = new Command("no", Text("cancel your choice"), (game, command) =>
            {
                var loop = game.InputLoops[^1] as YesNoLoop;
                loop.Response = false;
                loop.IsLooping = false;
            }
        );

        public static bool Get(Game game, VText question)
        {
            var loop = new YesNoLoop(game, question);
            game.AddLoop(loop);
            return loop.Response;
        }

        public YesNoLoop(Game game, VText question) : base(game, new List<Command> {YesCommand, NoCommand}, onLoop:
            g =>
            {
                WriteLine(question);
            })
        {
        }

        public bool Response { get; set; } = false;
    }
}