namespace HotelReservationLibrary.Pricing
{
    public class WeatherPricingAdjuster : IPricingAdjuster
    {
        private const decimal WeatherSurcharge = 1.2m;
        private readonly Weather.IWeatherService _weatherService;

        public WeatherPricingAdjuster(Weather.IWeatherService weatherService)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
        }

        public void AdjustPrice(Reservation reservation)
        {
            try
            {
                var forecast = _weatherService.GetForecast(
                    DateOnly.FromDateTime(reservation.CheckInDate),
                    DateOnly.FromDateTime(reservation.CheckOutDate));

                if (forecast.Summary == "Freezing" || forecast.Summary == "Sweltering")
                {
                    reservation.ApplySurcharge(WeatherSurcharge);
                }
            }
            catch (Exception)
            {
                // Weather service failed, continue without adjustment
                // In a real system, we'd log this exception
            }
        }
    }
}
