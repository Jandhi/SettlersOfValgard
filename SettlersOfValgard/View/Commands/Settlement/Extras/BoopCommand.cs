using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.Settlement.Extras
{
    public class BoopCommand : Command
    {
        public override string Name => "Boop";
        public override string[] Aliases { get; } = {"boop"};
        public override string UseCommandTo { get; } = "boop a settler";
        public UnlimitedStringArgument SettlerNameArgument = new UnlimitedStringArgument("Settler Name", "Specify settler name");
        public override List<Argument> Arguments => new List<Argument>{SettlerNameArgument};

        public override void Execute(Game game)
        {
            var settler =
                game.Settlement.Settlers.FirstOrDefault(s =>
                    String.Equals(s.Name, SettlerNameArgument.Contents, StringComparison.CurrentCultureIgnoreCase));
            if (settler == null)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: No settler with name {SettlerNameArgument.Contents} found");
            }
            else
            {
                CustomConsole.WriteLine($"Booped {settler.Name}!");
            }
        }
    }
}