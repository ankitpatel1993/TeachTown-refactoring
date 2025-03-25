namespace HotelReservationLibrary.Pricing
{
    public class SmokingPricingAdjuster : IPricingAdjuster
    {
        private const decimal SmokingSurcharge = 1.05m;

        public void AdjustPrice(Reservation reservation)
        {
            if (reservation.SmokingPreference == SmokingPreference.Smoking)
            {
                reservation.SetPrice(reservation.PricePerNight * SmokingSurcharge);
            }
        }
    }
}