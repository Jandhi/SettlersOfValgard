using System.Linq;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class HomeStatusCommand : Command
    {
        public override string Name => "Home Status";
        public override string[] Aliases { get; } = {"h", "HomeStatus", "homeStatus"};
        public override bool AvailableInMenu { get; } = false;
        public override string ToolTip => $"Use \"{Aliases[0]}\" to get the status of your settlement's homes";

        protected override void Execute(string[] args, Game game)
        {
            var families = game.Settlement.Families;

            if (args.Length == 0)
            {
                HomeStatus(game);
            }
        }

        private void HomeStatus(Game game)
        {
            var families = game.Settlement.Families;
            CustomConsole.WriteLine($"{families.Count(f => f.Home != null)} families have homes.");

            var homeless = families.Count(f => f.Home == null);
            if(homeless > 0) CustomConsole.WriteLine($"{CustomConsole.Red}{homeless} families are homeless.");

            var emptyHomes = 0;
            foreach (var building in game.Settlement.Buildings.Where(building =>  building is Residence))
            {
                var residence = (Residence) building;
                emptyHomes += (residence.MaxFamilies - residence.ResidentFamilies.Count);
            }
            if(emptyHomes > 0) CustomConsole.WriteLine($"{emptyHomes} empty homes.");
        }
    }
}