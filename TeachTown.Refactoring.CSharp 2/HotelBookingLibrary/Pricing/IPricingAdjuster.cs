namespace HotelReservationLibrary.Pricing
{
    public interface IPricingAdjuster
    {
        void AdjustPrice(Reservation reservation);
    }
}