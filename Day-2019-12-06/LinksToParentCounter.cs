using System.Collections.Generic;
using System.Linq;

namespace Day_2019_12_06
{
    public static class LinksToParentCounter
    {
        public static int Count(IEnumerable<Planet> planets)
        {
            return planets.Select(Count).Sum();
        }

        private static int Count(Planet planet)
        {
            var count = 0;
            while (planet.Parent != null)
            {
                count += 1;
                planet = planet.Parent;
            }
            return count;
        }
    }
}