using HotelReservationLibrary.Validation;

namespace HotelReservationLibrary.Validation
{
    public interface IReservationValidator
    {
        ValidationResult Validate(Reservation reservation);
    }

    public interface IPricingStrategy
    {
        decimal CalculateBasePrice(RoomType roomType);
        ValidationResult Validate(Reservation reservation);
    }

    public class ValidationResult
    {
        public bool IsValid { get; }
        public IReadOnlyList<string> Errors { get; }

        private ValidationResult(bool isValid, IReadOnlyList<string> errors)
        {
            IsValid = isValid;
            Errors = errors;
        }

        public static ValidationResult Success() => new ValidationResult(true, Array.Empty<string>());
        public static ValidationResult Failure(List<string> errors) => new ValidationResult(false, errors);
    }
}
