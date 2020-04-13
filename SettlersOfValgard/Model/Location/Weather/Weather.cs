namespace SettlersOfValgard.Model.Location.Weather
{
    public class Weather
    {
        public Temperature Temperature { get; }
        public Precipitation Precipitation { get; }
        
        public Weather(Temperature temperature, Precipitation precipitation)
        {
            Temperature = temperature;
            Precipitation = precipitation;
        }
        
        public override string ToString()
        {
            return $"{Precipitation} [Temperature: {Temperature}]";
        }
    }
}