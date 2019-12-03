using System;
using System.IO;
using System.Collections.Generic;
using Utils;

namespace Day_2019_12_03.App
{
    public static class Program
    {
        public static void Main()
        {
            var steps = File.ReadAllLines("data/input.txt");
            var wire0 = StepsParser.Parse(steps[0]);
            var wire1 = StepsParser.Parse(steps[1]);
            SolvePart1(wire0, wire1);
            SolvePart2(wire0, wire1);
        }

        private static void SolvePart1(IEnumerable<Segment2> wire0, IEnumerable<Segment2> wire1)
        {
            var distance = IntersectionFinder.FindDistanceOfClosestToOrigin(wire0, wire1);
            Console.WriteLine($"Part1: {distance}");
        }

        private static void SolvePart2(IEnumerable<Segment2> wire0, IEnumerable<Segment2> wire1)
        {
            var minDistance = SignalMinimizer.FindMinDistanceToIntersection(wire0, wire1);
            Console.WriteLine($"Part2: {minDistance}");
        }
    }
}