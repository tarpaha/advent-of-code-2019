using System;
using System.Linq;
using System.Collections.Generic;
using Utils;

namespace Day_2019_12_06.App
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }
        
        private readonly IEnumerable<Planet> _planets;
        private readonly string _planet1Name;
        private readonly string _planet2Name;

        public Solution()
        {
            var data = Input.GetData()
                .Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            _planets = Parser.Parse(data);
            _planet1Name = "YOU";
            _planet2Name = "SAN";
        }

        public object SolvePart1()
        {
            return LinksToParentCounter.Count(_planets);
        }

        public object SolvePart2()
        {
            var planet1 = _planets.First(p => p.Name == _planet1Name);
            var planet2 = _planets.First(p => p.Name == _planet2Name);
            return DistanceFinder.GetDistanceBetween(planet1, planet2);
        }
    }
}