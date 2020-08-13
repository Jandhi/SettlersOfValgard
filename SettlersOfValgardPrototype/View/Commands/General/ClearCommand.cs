using System;
using SettlersOfValgard.View.Commands.Core;

namespace SettlersOfValgard.View.Commands.General
{
    public class ClearCommand : Command
    {
        public override string Name => "Clear";
        public override string[] Aliases { get; } = {"clear"};
        public override string UseCommandTo => "clear the screen";
        public override void Execute(Game game)
        {
            Console.Clear();
        }
    }
}