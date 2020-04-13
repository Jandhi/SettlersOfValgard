using System;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class BuildingCommand : OldCommand.Command
    {
        public override string Name => "Building";
        public override string[] Aliases { get; } = {"b", "building", "Building"};
        public override bool AvailableInMenu => false;
        public override string ToolTip => $"Use \"";

        protected override void Execute(string[] args, Game game)
        {
            var stringBuilder = new StringBuilder();
            var numbered = false;
            var separated = false;
            int position = -100;

            foreach (var arg in args)
            {
                try
                {
                    position = IntegerType.FromString(arg);
                    continue;
                }
                catch (InvalidCastException e) {}
                
                if (arg == "-n")
                {
                    numbered = true;
                }
                else if (arg == "-s")
                {
                    separated = true;
                }
                else
                {
                    if (stringBuilder.Length > 0) stringBuilder.Append(" ");
                    stringBuilder.Append(arg);
                }
            }
            
            if (stringBuilder.Length == 0)
            {
                IOManager.ListInConsole(game.Settlement.Buildings, numbered, separated);
            }
            else
            {
                var name = stringBuilder.ToString();
                int count = 0;
                Building item = null;

                foreach (var building in game.Settlement.Buildings)
                {
                    if (building.Name == name)
                    {
                        count++;
                        if (count == position || count < 0)
                        {
                            item = building;
                            break;
                        }
                    }
                }

                if (item != null)
                {
                    var ordinal = position < 0 ? "" : $" #{position}";
                    CustomConsole.WriteLine($"{item}{ordinal}");
                }
            }
        }
    }
}