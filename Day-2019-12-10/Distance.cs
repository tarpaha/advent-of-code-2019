using Utils;

namespace Day_2019_12_10
{
    public static class Distance
    {
        public static (int dx, int dy, int length) Calculate(IAsteroid from, IAsteroid to)
        {
            return Mathematics.ReduceFraction(to.X - from.X, to.Y - from.Y);
        }
    }
}