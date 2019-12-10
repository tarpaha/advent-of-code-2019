using System;

namespace Utils
{
    public static class Mathematics
    {
        public static (int a, int b, int n) ReduceFraction(int a, int b)
        {
            var n = 1;
            var min = Math.Abs(a) < Math.Abs(b) ? Math.Abs(a) : Math.Abs(b);
            for (var div = 2; div <= min; div++)
            {
                if (a % div == 0 && b % div == 0)
                {
                    n *= div;
                    a /= div;
                    b /= div;
                    min /= div;
                    div = 1;
                }
            }
            return (a, b, n);
        }
    }
}