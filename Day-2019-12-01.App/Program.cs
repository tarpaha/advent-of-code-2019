using System;
using System.IO;
using System.Linq;

namespace Day_2019_12_01.App
{
    public static class Program
    {
        public static void Main()
        {
            var input = File
                .ReadAllLines("data/input.txt")
                .Select(int.Parse)
                .ToList();

            var solutionPart1 = new SolutionPart1();
            var answerPart1 = input
                .Select(mass => solutionPart1.CalculateRequiredFuel(mass))
                .Sum();
            Console.WriteLine($"Part1: {answerPart1}");
            
            var solutionPart2 = new SolutionPart2();
            var answerPart2 = input
                .Select(mass => solutionPart2.CalculateRequiredFuel(mass))
                .Sum();
            Console.WriteLine($"Part2: {answerPart2}");
        }
    }
}