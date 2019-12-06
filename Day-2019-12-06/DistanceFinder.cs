using System.Collections.Generic;
using System.Linq;

namespace Day_2019_12_06
{
    public static class DistanceFinder
    {
        public static IEnumerable<Planet> GetPathFromRoot(Planet planet)
        {
            var path = new List<Planet>();
            while (planet.Parent != null)
            {
                path.Add(planet.Parent);
                planet = planet.Parent;
            }
            path.Reverse();
            return path;
        }

        public static int GetDistanceToParent(Planet planet, Planet parent)
        {
            var distance = 0;
            while (planet.Parent != parent)
            {
                distance += 1;
                planet = planet.Parent;
            }
            return distance;
        }
        
        public static int GetDistanceBetween(Planet planet1, Planet planet2)
        {
            var path1 = GetPathFromRoot(planet1).ToArray();
            var path2 = GetPathFromRoot(planet2).ToArray();
            
            var minCommonParentId = 0;
            while (true)
            {
                if(minCommonParentId >= path1.Length)
                    break;
                if (minCommonParentId >= path2.Length)
                    break;
                if (path1[minCommonParentId] != path2[minCommonParentId])
                    break;
                minCommonParentId += 1;
            }
            var minCommonParent = path1[minCommonParentId - 1];
            
            return GetDistanceToParent(planet1, minCommonParent) + GetDistanceToParent(planet2, minCommonParent);
        }
    }
}