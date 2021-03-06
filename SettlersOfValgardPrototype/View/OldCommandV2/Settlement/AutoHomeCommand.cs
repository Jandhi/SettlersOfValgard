﻿using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class AutoHomeCommand : Command
    {
        public override string Name => "AutoHome";
        public override string[] Aliases { get; } = {"ah", "AH", "Ah", "autohome", "Autohome", "autoHome", "AutoHome"};
        public override List<Argument> Arguments => new List<Argument>();
        public override List<Argument> OptionalArguments => new List<Argument>();
        public override List<Tag> Tags => new List<Tag>();
        public override string UseCommandTo => "Automatically provide the best homes to settler families.";
        public override void Execute(Game game)
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