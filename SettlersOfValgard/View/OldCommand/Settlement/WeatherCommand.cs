using SettlersOfValgard.Model.Location.Weather;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class WeatherCommand : OldCommand.Command
    {
        public override string Name => "Weather";
        public override string[] Aliases { get; } = {"wt", "weather", "Weather"};
        public override string ToolTip => $"Use \"{Aliases[0]}\" to display today's weather.";
        protected override void Execute(string[] args, Game game)
        {
            var weather = game.Settlement.TodaysWeather;
            CustomConsole.WriteLine($"Today's weather: {weather}.");
        }
    }
}