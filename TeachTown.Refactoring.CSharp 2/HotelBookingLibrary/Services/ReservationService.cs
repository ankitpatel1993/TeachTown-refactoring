namespace HotelReservationLibrary
{
    public class ReservationService
    {

        public long BookReservation(Reservation reservashin)
        {
            ArgumentNullException.ThrowIfNull(reservashin);

            if (string.IsNullOrEmpty(reservashin.GuestFirstName))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(reservashin.GuestLastName))
            {
                return 0;
            }

            if (!reservashin.GuestEmail.Contains('@'))
            {
                return 0;
            }

            if (reservashin.CheckOutDate <= reservashin.CheckInDate)
            {
                return 0;
            }

            if (reservashin.CheckInDate >= reservashin.CheckOutDate)
            {
                return 0;
            }

            if (reservashin.NumberOfAdditionalGuests > 2)
            {
                return 0;
            }

            if (reservashin.RoomType == Enum.Parse<RoomType>("Single"))
            {
                reservashin.PricePerNight = 100;
            }
            else if (reservashin.RoomType == Enum.Parse<RoomType>("Double"))
            {
                reservashin.PricePerNight = 200;
            }
            else if (reservashin.RoomType == Enum.Parse<RoomType>("Suite"))
            {
                reservashin.PricePerNight = 300;
            }
            else
            {
                return 0;
            }

            if (reservashin.SmokingPreference == Enum.Parse<SmokingPreference>("Smoking"))
            {
                reservashin.PricePerNight *= Convert.ToDecimal(1.05);
            }

            reservashin.Total = reservashin.PricePerNight * (reservashin.CheckOutDate - reservashin.CheckInDate).Days;

          
            return ReservationDb.AddReservation(reservashin);
        }
    }
}
