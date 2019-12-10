using System;
using System.Linq;
using System.Collections.Generic;
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

        private readonly int _n;
        private readonly IEnumerable<IAsteroid> _planets;

        public Solution()
        {
            _n = 200;
            _planets = Reader.Read(Input.GetData()); 
        }

        public object SolvePart1()
        {
            return Visibility.GetMostVisibleCount(_planets).count;
        }

        public object SolvePart2()
        {
            var baseAsteroid = Visibility.GetMostVisibleCount(_planets).asteroid;
            var nthDestroyed = Laser.GetNthDestroyedAsteroid(_n, baseAsteroid, _planets);
            return 100 * nthDestroyed.X + nthDestroyed.Y;
        }
    }
}