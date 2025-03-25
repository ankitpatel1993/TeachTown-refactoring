namespace HotelReservationLibrary
{
    public class Reservation
    {
        internal object guestEmail;

        public string GuestFirstName { get; set; } = string.Empty;
        public string GuestLastName { get; set; } = string.Empty;
        public string GuestEmail { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfAdditionalGuests { get; set; }
        public RoomType RoomType { get; set; }
        public SmokingPreference SmokingPreference { get; set; }
        public decimal PricePerNight { get; set; }
        public decimal Total { get; set; }

        public Reservation() { }

        public static Reservation Create(
            string firstName,
            string lastName,
            string email,
            DateTime checkInDate,
            DateTime checkOutDate,
            int additionalGuests,
            RoomType roomType,
            SmokingPreference smokingPreference)
        {
            return new Reservation
            {
                GuestFirstName = firstName,
                GuestLastName = lastName,
                GuestEmail = email,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                NumberOfAdditionalGuests = additionalGuests,
                RoomType = roomType,
                SmokingPreference = smokingPreference
            };
        }

        public void SetPrice(decimal pricePerNight)
        {
            PricePerNight = pricePerNight;
        }

        public void CalculateTotal(int numberOfNights)
        {
            Total = PricePerNight * numberOfNights;
        }

        public void ApplySurcharge(decimal surchargeMultiplier)
        {
            Total *= surchargeMultiplier;
        }
    }
}
