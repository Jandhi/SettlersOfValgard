using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Building.Workplace;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;

namespace SettlersOfValgard.View.Commands.Settlement.Auto
{
    public class AutoWorkCommand : Command
    {
        public override string Name => "AutoWork";
        public override string[] Aliases { get; } = {"aw", "autowork", "AutoWork", "autoWork"};
        public override string UseCommandTo => "Automatically provide workplaces for unemployed settlers";
        public override void Execute(Game game)
        {
            var unemployed = game.Settlement.Settlers.Where(settler =>
                settler.CanWork(game.Settlement) && settler.Workplace == default).ToList();

            if (unemployed.Count == 0)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: No settlers to employ!");
            }
            else
            {
                var employedCount = 0;
                foreach (var unemployedSettler in unemployed)
                {
                    var workplace =
                        game.Settlement.Buildings.OfType<Workplace>();
                    var unfilledWorkplace = workplace.FirstOrDefault(work => !work.IsFull);
                    if (unfilledWorkplace == null) break;
                    unfilledWorkplace.AddWorker(unemployedSettler);
                    employedCount++;
                }

                if (employedCount == 0)
                {
                    CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: No empty workplaces!");
                }
                else
                {
                    CustomConsole.WriteLine($"{CustomConsole.Green}Employed {employedCount} settlers!");
                }
            }
            
        }
    }
}