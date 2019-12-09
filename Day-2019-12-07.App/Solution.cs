using System;
using System.Linq;
using Utils;

namespace Day_2019_12_07.App
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }

        private readonly int[] _program;

        public Solution()
        {
            _program = Input.GetData()
                .Split(',')
                .Select(int.Parse)
                .ToArray();
        }

        public object SolvePart1()
        {
            return Circuit1.GetHighestSignal(_program);
        }

        public object SolvePart2()
        {
            return Circuit2.GetHighestSignal(_program);
        }
    }
}