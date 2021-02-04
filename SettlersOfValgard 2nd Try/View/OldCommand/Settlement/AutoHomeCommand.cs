using System.Linq;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.OldCommand.Settlement
{
    public class AutoHomeCommand : OldCommand.Command
    {
        public override string Name => "Autohome";
        public override string[] Aliases { get; } = {"ah", "autohome", "AH", "aH", "Ah", "autoHome"};
        public override string ToolTip => $"Use \"{Aliases[0]}\" to automatically move the homeless into empty homes.";

        protected override void Execute(string[] args, Game game)
        {
            var homelessFamilies = game.Settlement.Families.Where(family => family.Home == null).ToList();
            var homelessFamilyCount = homelessFamilies.Count();
            
            if (homelessFamilyCount > 0)
            {
                var rehomedFamilyCount = 0;
                
                foreach (var family in homelessFamilies)
                {
                    foreach (var building in game.Settlement.Buildings.Where(building => building is Residence))
                    {
                        var residence = (Residence) building;
                        if (!residence.IsFull)
                        {
                            residence.AddResident(family);
                            homelessFamilyCount--;
                            rehomedFamilyCount++;
                            break;
                        }
                    }
                }

                if (rehomedFamilyCount == 0)
                {
                    CustomConsole.WriteLine($"{CustomConsole.Red}No homes are empty!");
                }
                else
                {
                    CustomConsole.WriteLine($"{CustomConsole.Green}{rehomedFamilyCount} families have been rehomed.");
                }
                
                if (homelessFamilyCount > 0)
                {
                    CustomConsole.WriteLine($"{CustomConsole.Red}{homelessFamilyCount} families are still homeless!");
                }
            }
            else
            {
                CustomConsole.WriteLine("No families are homeless.");
            }
        }
    }
}