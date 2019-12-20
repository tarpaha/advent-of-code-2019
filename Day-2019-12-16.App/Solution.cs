using System;
using System.Linq;
using Utils;

namespace Day_2019_12_16.App
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
            var input = Input.GetData().Select(ch => ch - '0').ToArray();
            var output = FFT.Process(input, 100);
            return int.Parse(string.Join("", output.Take(8)));
        }

        public object SolvePart2()
        {
            return null;
        }
    }
}