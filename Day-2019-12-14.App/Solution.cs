using System;
using Utils;

namespace Day_2019_12_14.App
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
            var data = Input.GetData();
            var reactions = Parser.Parse(data);
            return Solver.CalculateOreAmountForFuel(reactions);
        }

        public object SolvePart2()
        {
            var data = Input.GetData();
            var reactions = Parser.Parse(data);
            return Solver.CalculateFuelAmountForTrillionOre(reactions);
        }
    }
}