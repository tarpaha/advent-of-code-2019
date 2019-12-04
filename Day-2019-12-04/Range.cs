using System.Collections.Generic;
using System.Linq;

namespace Day_2019_12_04
{
    public static class Range
    {
        public static IEnumerable<int> Get(int min, int max)
        {
            return Enumerable.Range(min, max - min + 1);
        }
    }
}