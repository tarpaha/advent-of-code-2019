using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day_2019_12_06.App
{
    public static class Program
    {
        public static void Main()
        {
            var data = File.ReadAllLines("data/input.txt");
            var planets = Parser.Parse(data);

            SolvePart1(planets);
            SolvePart2(planets, "YOU", "SAN");
        }

        private static void SolvePart1(IEnumerable<Planet> planets)
        {
            var linksCount = LinksToParentCounter.Count(planets);
            Console.WriteLine($"Part1: {linksCount}");
        }
        
        private static void SolvePart2(IEnumerable<Planet> planets, string planet1Name, string planet2Name)
        {
            var planet1 = planets.First(p => p.Name == planet1Name);
            var planet2 = planets.First(p => p.Name == planet2Name);
            var distance = DistanceFinder.GetDistanceBetween(planet1, planet2);
            Console.WriteLine($"Part2: {distance}");
        }
    }
}