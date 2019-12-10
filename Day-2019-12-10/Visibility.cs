using System.Collections.Generic;
using System.Linq;

namespace Day_2019_12_10
{
    public static class Visibility
    {
        public static int VisibleCount(IAsteroid from, IEnumerable<IAsteroid> field)
        {
            return field
                .Where(asteroid => asteroid != from)
                .Select(asteroid => Distance.Calculate(from, asteroid))
                .Select(d => (d.dx, d.dy))
                .Distinct()
                .Count();
        }
    }
}