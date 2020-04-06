using SettlersOfValgard.Model.Location.Weather;
using SettlersOfValgard.Model.Rank;
using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Info
{
    public class ListCommand : Command
    {
        public override string Name { get; } = "List";
        public override string[] Aliases { get; } = {"list"};
        public override bool AvailableInMenu => true;
        public override string ToolTip => $"Use \"{Aliases[0]}\" to list enumerated values in console.";

        protected override void Execute(string[] args, Game game)
        {
            if (args.Length == 1)
            {
                switch (args[0])
                {
                    case "season":
                    case "Season":
                        IOManager.ListInConsole(Season.Seasons);
                        break;
                    
                    case "temp":
                    case "Temp":
                    case "Temperature":
                    case "temperature":
                        IOManager.ListInConsole(Temperature.Temperatures);
                        break;
                    
                    case "Precip":
                    case "precip":
                    case "Precipitation":
                    case "precipitation":
                        IOManager.ListInConsole(Precipitation.Precipitations);
                        break;
                    
                    case "playerrank":
                    case "playerRank":
                    case "Playerrank":
                    case "PlayerRank":
                    case "rank":
                        IOManager.ListInConsole(PlayerRank.Ranks);
                        break;
                    
                    default:
                        CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: Unknown argument: \"{args[0]}\"");
                        return;
                }
            }
        }
    }
}