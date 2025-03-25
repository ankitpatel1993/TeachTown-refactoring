using HotelReservationLibrary.Common;

namespace HotelReservationLibrary.Weather
{
    public sealed class ExternalWeatherService : IWeatherService
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IRandomGenerator _randomGenerator;

        public ExternalWeatherService(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator ?? throw new ArgumentNullException(nameof(randomGenerator));
        }

        public WeatherForecast GetForecast(DateOnly startDate, DateOnly endDate)
        {
            var date = startDate.AddDays(1);
            var temperatureC = _randomGenerator.Next(-20, 55);
            var summary = Summaries[_randomGenerator.Next(Summaries.Length)];

            return new WeatherForecast(date, temperatureC, summary);
        }
    }
}