using System;
using System.Linq;

namespace Day_2019_12_04
{
    public static class Solver
    {
        public static int GetCorrectPasswordsFromRangeType(int min, int max, Func<int[], bool> correctFunc)
        {
            return Range
                .Get(min, max)
                .AsParallel()
                .Select(Converter.ToSixDigits)
                .Where(correctFunc)
                .Count();
        }
    }
}