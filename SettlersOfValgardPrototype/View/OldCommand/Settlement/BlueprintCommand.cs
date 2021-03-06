﻿using System;
using System.Linq;
using System.Text;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.Model.Building.Workplace;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.OldCommand.Settlement
{
    public class BlueprintCommand : OldCommand.Command
    {
        public override string Name => "Blueprint";
        public override string[] Aliases { get; } = {"bp", "blueprint", "Blueprint"};
        public override bool AvailableInMenu => false;

        public override string ToolTip =>
            $"Use \"{Aliases[0]}\" to list your available blueprints, or \"{Aliases[0]} [name]\" to show a specific blueprint.";

        protected override void Execute(string[] args, Game game)
        {
            if (args.Length == 0)
            {
                CustomConsole.WriteLine("Blueprints:");
                CustomConsole.TitleLine();
                IOManager.ListInConsole(game.Settlement.Blueprints);
            }
            else
            {
                string name;
                var sb = new StringBuilder(args[0]);
                for (int i = 1; i < args.Length; i++)
                {
                    sb.Append(" ").Append(args[1]);
                }

                name = sb.ToString();
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