using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_2019_12_03
{
    public static class IntersectionFinder
    {
        public static int FindDistanceOfClosestToOrigin(IEnumerable<Segment2> wire0, IEnumerable<Segment2> wire1)
        {
            return FindIntersections(wire0, wire1)
                .Select(p => p.Manhattan)
                .Where(d => d != 0)
                .Min();
        }
        
        public static IEnumerable<Vector2> FindIntersections(IEnumerable<Segment2> wire0, IEnumerable<Segment2> wire1)
        {
            var intersections = new List<Vector2>();
            foreach (var s0 in wire0)
            {
                foreach (var s1 in wire1)
                {
                    if (Geometry.Intersect(s0, s1, out var intersection))
                    {
                        intersections.Add(intersection);
                    }
                }
            }
            return intersections;
        }
    }
}