using System;
using System.Collections.Generic;
using System.IO;

namespace Day_2019_12_06.App
{
    public static class Program
    {
        public static void Main()
        {
            var data = File.ReadAllLines("data/input.txt");
            var planets = Parser.Parse(data);

            SolvePart1(planets);
        }

        private static void SolvePart1(IEnumerable<Planet> planets)
        {
            var linksCount = LinksToParentCounter.Count(planets);
            Console.WriteLine($"Part1: {linksCount}");
        }
    }
}