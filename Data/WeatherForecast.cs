using System;

namespace WeatherForcast.Data
{
    public class WeatherForecast
    {
        public City City { get; set; }

        public DateTime Date { get; set; }

        public double TemperatureC { get; set; }

        public double TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public enum TemperatureType
    {
        Celsius,
        Fahrenhait
    }
}
