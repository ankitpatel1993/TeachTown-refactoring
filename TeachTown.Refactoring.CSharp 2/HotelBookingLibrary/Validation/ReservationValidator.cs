using HotelReservationLibrary.Validation;

namespace HotelReservationLibrary.Validation
{
    public class ReservationValidator : IReservationValidator
    {
        public ValidationResult Validate(Reservation reservation)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(reservation.GuestFirstName))
            {
                errors.Add("First name is required");
            }

            if (string.IsNullOrEmpty(reservation.GuestLastName))
            {
                errors.Add("Last name is required");
            }

            if (!reservation.GuestEmail.Contains('@'))
            {
                errors.Add("Invalid email format");
            }

            if (reservation.CheckOutDate <= reservation.CheckInDate)
            {
                errors.Add("Check-out date must be after check-in date");
            }

            if (reservation.NumberOfAdditionalGuests > 2)
            {
                errors.Add("Maximum 2 additional guests allowed");
            }

            return errors.Count > 0
                ? ValidationResult.Failure(errors)
                : ValidationResult.Success();
        }

        //public ValidationResult Validate(Reservation reservation)
        //{
        //    throw new NotImplementedException();
        //}

        ValidationResult IReservationValidator.Validate(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}

