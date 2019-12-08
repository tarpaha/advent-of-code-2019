using System;
using System.Collections.Generic;
using Utils;

namespace Day_2019_12_03.App
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }

        private readonly IEnumerable<Segment2> _wire0;
        private readonly IEnumerable<Segment2> _wire1;

        public Solution()
        {
            var steps = Input.GetData()
                .Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            _wire0 = StepsParser.Parse(steps[0]);
            _wire1 = StepsParser.Parse(steps[1]);
        }

        public int SolvePart1()
        {
            return IntersectionFinder.FindDistanceOfClosestToOrigin(_wire0, _wire1);
        }

        public int SolvePart2()
        {
            return SignalMinimizer.FindMinDistanceToIntersection(_wire0, _wire1);
        }
    }
}