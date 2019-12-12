using System;
using Utils;

namespace Day_2019_12_12.App
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }

        private readonly int _steps;
        private readonly Space _space;
        
        public Solution()
        {
            _steps = 1000;
            _space = new Space(Parser.ParsePoints(Input.GetData()));
        }

        public object SolvePart1()
        {
            for(var i = 0; i < _steps; i++)
                _space.Step();
            return _space.TotalEnergy;
        }

        public object SolvePart2()
        {
            return null;
        }
    }
}