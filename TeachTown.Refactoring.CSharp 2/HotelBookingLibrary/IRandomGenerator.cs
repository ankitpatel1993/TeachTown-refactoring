namespace HotelReservationLibrary.Common
{
    public interface IRandomGenerator
    {
        int Next(int minValue, int maxValue);
        int Next(int maxValue);
    }
}