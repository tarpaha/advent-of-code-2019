using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_2019_12_03
{
    public static class SignalMinimizer
    {
        public static int FindMinDistanceToIntersection(IEnumerable<Segment2> wire0, IEnumerable<Segment2> wire1)
        {
            var intersections = IntersectionFinder.FindIntersections(wire0, wire1).Where(p => p.Manhattan != 0);
            var minDistance = int.MaxValue;
            foreach (var intersection in intersections)
            {
                var distance = GetDistanceToPoint(wire0, intersection) + GetDistanceToPoint(wire1, intersection);
                if (distance < minDistance)
                    minDistance = distance;
            }
            return minDistance;
        }

        private static int GetDistanceToPoint(IEnumerable<Segment2> wire, Vector2 point)
        {
            var distance = 0;
            foreach (var segment in wire)
            {
                var d = Geometry.DistanceFromSegmentStart(segment, point);
                if (d > 0)
                {
                    distance += d;
                    break;
                }
                distance += segment.Length;
            }
            return distance;
        }
    }
}