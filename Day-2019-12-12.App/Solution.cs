using System;
using System.Collections.Generic;
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
        private readonly IEnumerable<Vector3> _points;
        
        public Solution()
        {
            _steps = 1000;
            _points = Parser.ParsePoints(Input.GetData());
        }

        public object SolvePart1()
        {
            var space = new Space(_points);
            for(var i = 0; i < _steps; i++)
                space.Step();
            return space.TotalEnergy;
        }

        public object SolvePart2()
        {
            return new Space(_points).GetRepeatPeriod();
        }
    }
}