using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.Settlement.Building
{
    public class HomeCommand : Command
    {
        public override string Name => "Home";
        public override string[] Aliases { get; } = {"h", "home", "Home"};
        public override string UseCommandTo => "Set the home of a settler's family";
        
        public UnlimitedStringArgument SettlerNameArgument = new UnlimitedStringArgument("Settler Name", "The name of the settler whose home to check");
        public override List<Argument> Arguments => new List<Argument>{SettlerNameArgument};
        public StringArgument ResidenceNameArgument = new StringArgument("Residence Name", "The name of the residence");
        public NaturalNumberArgument NaturalNumberArgument = new NaturalNumberArgument("Number of residence", "The number of the residence to use");
        public override List<Argument> OptionalArguments => new List<Argument>{ResidenceNameArgument, NaturalNumberArgument};

        public override void Execute(Game game)
        {
            if (!ResidenceNameArgument.IsFilled)
            {
                var settlerList = game.Settlement.Settlers.Where(settler =>
                    StringsUtil.IsMatchingStartIgnoreCase(settler, SettlerNameArgument.Contents)).ToList();
                if (settlerList.Count == 0)
                {
                    CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: No settler with name starting with \"{SettlerNameArgument.Contents}\" found!");
                }
                else if(settlerList.Count == 1)
                {
                    var settler = settlerList[0];
                    var home = settler.Family.Home ?? null;

                    if (home != null)
                    {
                        CustomConsole.TitleLine();
                        CustomConsole.WriteLine($"{settler.Name.ToUpper()}'S HOME:");
                        CustomConsole.WriteLine($"{home.Name}");
                        CustomConsole.WriteLine($"{home.Description}");
                        CustomConsole.WriteLine($"Heat: {home.GetIndoorTemperature(game.Settlement)}");
                        CustomConsole.WriteLine($"Residents:");
                        foreach (var family in home.ResidentFamilies)
                        {
                            foreach (var member in family.Members)
                            {
                                CustomConsole.WriteLine($"{member} ({family.Name})");
                            }
                        }
                    }
                    else
                    {
                        CustomConsole.WriteLine($"{settler}{CustomConsole.Red} is homeless!");
                    }
                }
                else
                {
                    CustomConsole.WriteLine($"Settlers with name starting with \"{SettlerNameArgument.Contents}\":");
                    IOManager.ListInConsole(settlerList);
                }
            }
            else
            {
                if (NaturalNumberArgument.IsFilled)
                {

                }
                else
                {
                    
                }
            }
        }
    }
}