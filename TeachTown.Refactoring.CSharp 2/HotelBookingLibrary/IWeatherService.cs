namespace HotelReservationLibrary.Weather
{
    public interface IWeatherService
    {
        WeatherForecast GetForecast(DateOnly startDate, DateOnly endDate);
    }
}