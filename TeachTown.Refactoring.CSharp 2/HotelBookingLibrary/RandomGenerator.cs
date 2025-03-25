namespace HotelReservationLibrary.Common
{
    public class RandomGenerator : IRandomGenerator
    {
        public int Next(int minValue, int maxValue) => Random.Shared.Next(minValue, maxValue);
        public int Next(int maxValue) => Random.Shared.Next(maxValue);
    }
}
