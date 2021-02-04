using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;

namespace SettlersOfValgard.View.Commands.Settlement.Location
{
    public class WeatherCommand : Command
    {
        public override string Name => "Weather";
        public override string[] Aliases { get; } = {"w"};
        public override string UseCommandTo => "check today's weather.";
        public override void Execute(Game game)
        {
            CustomConsole.WriteLine($"{game.Settlement.TodaysWeather}");
        }
    }
}