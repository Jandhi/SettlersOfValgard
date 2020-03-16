namespace SettlersOfValgard.Model.Location
{
    public abstract class Location
    {
        public abstract Weather.Weather GenerateWeather();
    }
}