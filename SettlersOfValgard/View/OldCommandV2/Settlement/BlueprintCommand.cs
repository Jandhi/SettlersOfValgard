using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.Model.Building.Workplace;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class BlueprintCommand : Command
    {
        public override string Name { get; }
        public override string[] Aliases { get; }
        public override List<Argument> Arguments => new List<Argument>();
        public override List<Argument> OptionalArguments => new List<Argument>{BlueprintName};
        public override List<Tag> Tags { get; }
        public override string UseCommandTo { get; }
        
        public StringArgument BlueprintName { get; } = new StringArgument("");

        public override void Execute(Game game)
        {
            if (!BlueprintName.IsUsable())
            {
                CustomConsole.WriteLine("Blueprints:");
                CustomConsole.TitleLine();
                IOManager.ListInConsole(game.Settlement.Blueprints);
            }
            else
            {
                string name = BlueprintName.Contents;
                
                var bp = game.Settlement.Blueprints.FirstOrDefault(b =>
                    string.Equals(b.Name, name, StringComparison.CurrentCultureIgnoreCase));

                if (bp == null)
                {
                    CustomConsole.WriteLine($"{CustomConsole.Red}No Blueprint named {name} found!");
                }
                else
                {
                    CustomConsole.WriteLine($"{bp.Name}:");
                    CustomConsole.TitleLine();
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
    }
}