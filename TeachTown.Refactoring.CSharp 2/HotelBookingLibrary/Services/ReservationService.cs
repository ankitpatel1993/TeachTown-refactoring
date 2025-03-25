//using HotelReservationLibrary.Data;
//using HotelReservationLibrary.Models;
//using HotelReservationLibrary.Pricing;
//using HotelReservationLibrary.Validation;


//namespace HotelReservationLibrary.Services
//{

//    public class ReservationService
//    {
//        private readonly IReservationValidator _validator;
//        private readonly IPricingStrategy _pricingStrategy;
//        private readonly IEnumerable<IPricingAdjuster> _pricingAdjusters;
//        private readonly IReservationRepository _repository;

//        public ReservationService()
//        {
//        }

//        public ReservationService(
//            IReservationValidator validator,
//            IPricingStrategy pricingStrategy,
//            IEnumerable<IPricingAdjuster> pricingAdjusters,
//            IReservationRepository repository)
//        {
//            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
//            _pricingStrategy = pricingStrategy ?? throw new ArgumentNullException(nameof(pricingStrategy));
//            _pricingAdjusters = pricingAdjusters ?? throw new ArgumentNullException(nameof(pricingAdjusters));
//            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
//        }

//        public ReservationResult BookReservation(Reservation reservation)
//        {
//            ArgumentNullException.ThrowIfNull(reservation);

//            // Validate the reservation
//            var validationResult = _validator.Validate(reservation);
//            if (!validationResult.IsValid)
//            {
//                return ReservationResult.Failure(validationResult.Errors);
//            }

//            // Set the base price
//            var basePrice = _pricingStrategy.CalculateBasePrice(reservation.RoomType);
//            reservation.SetPrice(basePrice);

//            // Apply pricing adjusters
//            foreach (var adjuster in _pricingAdjusters)
//            {
//                adjuster.AdjustPrice(reservation);
//            }

//            // Calculate total price
//            int stayDuration = (reservation.CheckOutDate - reservation.CheckInDate).Days;
//            reservation.CalculateTotal(stayDuration);

//            // Save to repository
//            var reservationId = _repository.Add(reservation);

//            return ReservationResult.Success(reservationId);
//        }
//    }

//    public class ReservationResult
//    {
//        public bool IsSuccess { get; }
//        public long ReservationId { get; }
//        public IReadOnlyList<string> Errors { get; }

//        private ReservationResult(bool isSuccess, long reservationId, IReadOnlyList<string> errors)
//        {
//            IsSuccess = isSuccess;
//            ReservationId = reservationId;
//            Errors = errors;
//        }

//        public static ReservationResult Success(long reservationId) =>
//            new ReservationResult(true, reservationId, Array.Empty<string>());

//        public static ReservationResult Failure(IReadOnlyList<string> errors) =>
//            new ReservationResult(false, 0, errors);
//    }
//}

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