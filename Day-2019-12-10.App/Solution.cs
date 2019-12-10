using System;
using Utils;

namespace Day_2019_12_10.App
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }

        public object SolvePart1()
        {
            var planets = Reader.Read(Input.GetData());
            return Visibility.GetMostVisibleCount(planets);
        }

        public object SolvePart2()
        {
            return null;
        }
    }
}