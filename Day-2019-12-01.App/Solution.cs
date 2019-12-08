using System;
using System.Linq;
using System.Collections.Generic;
using Utils;

namespace Day_2019_12_01.App
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }
        
        private readonly List<int> _input;

        public Solution()
        {
            _input= Input.GetData()
                .Split(new []{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }

        public int SolvePart1()
        {
            var solutionPart1 = new SolutionPart1();
            return _input
                .Select(mass => solutionPart1.CalculateRequiredFuel(mass))
                .Sum();
        }

        public int SolvePart2()
        {
            var solutionPart2 = new SolutionPart2();
            return _input
                .Select(mass => solutionPart2.CalculateRequiredFuel(mass))
                .Sum();
        }
    }
}