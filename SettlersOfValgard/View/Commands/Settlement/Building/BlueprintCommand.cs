using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.Model.Building.Workplace;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.Settlement.Building
{
    public class BlueprintCommand : ListOrDisplayCommand<Blueprint>
    {
        public override string Name => "Blueprint";
        public override string[] Aliases { get; } = {"bp", "blueprint", "blueprints"};

        public override string Type { get; } = "Blueprint";
        public override List<Blueprint> GetList(Game game)
        {
            return game.Settlement.Blueprints;
        }

        public override void Display(Blueprint bp)
        {
            CustomConsole.TitleLine();
            CustomConsole.WriteLine($"{bp.Name.ToUpper()}:");
            if (bp.Building is Workplace)
            {
                CustomConsole.WriteLine($"Workplace");
            } else if (bp.Building is Residence)
            {
                CustomConsole.WriteLine($"Residence");
            }
            CustomConsole.WriteLine($"Cost: {bp.Cost}");
            CustomConsole.WriteLine($"{bp.Description}");
        }
    }
}