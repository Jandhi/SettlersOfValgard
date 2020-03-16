using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SettlersOfValgard.Model.Settler.Skill;
using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settler
{
    public class SettlerCommand : Command
    {
        public override string Name => "Settler";
        public override string[] Aliases { get; } = {"s", "Settler", "settler"};
        public override bool NeedsValidation => false;
        public override bool AvailableInMenu => false;
        protected override void Execute(string[] args, Game game)
        {
            if (args.Length == 0)
            {
                ListSettlers(game);
            }
            else
            {
                StringBuilder s = new StringBuilder();
                s.Append(args[0]);
                for (int i = 1; i < args.Length; i++) s.Append($" {args[i]}");
                var settler = FindSettler(game, s.ToString());
                if(settler != null) {
                    DisplaySettler(game, settler);
                }
            }
            
        }

        private void FindSettlersWithPrefix(Game game, string prefix)
        {
            var match =
                from settler in game.Settlement.Settlers
                where settler.Name.StartsWith(prefix)
                select settler;
            IOManager.ListInConsole(match);
        }

        private Model.Settler.Settler FindSettler(Game game, string name)
        {
            return game.Settlement.Settlers.FirstOrDefault(settler => settler.Name == name);
        }

        private void DisplaySettler(Game game, Model.Settler.Settler settler)
        {
            if (settler == null)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: No such settler exists");
            }
            else
            {
                CustomConsole.WriteLine($"{settler.Name}");
                CustomConsole.VerticalLine();
                CustomConsole.WriteLine($"Age: {Date.DaysToYears(Date.AgeInDays(settler, game.Settlement))}");

                foreach (var (skill, xp) in settler.Experience)
                {
                    CustomConsole.WriteLine($"{SkillLevel.XPtoLevel(xp)} {skill}");
                }
            }
        }

        private void ListSettlers(Game game)
        {
            IOManager.ListInConsole(game.Settlement.Settlers);
        }
    }
}