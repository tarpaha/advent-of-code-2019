using System;
//using System.Linq;

namespace Day_2019_12_04.App
{
    public static class Program
    {
        public static void Main()
        {
            const int min = 124075;
            const int max = 580769;
            SolvePart1(min, max);
            SolvePart2(min, max);
        }

        private static void SolvePart1(int min, int max)
        {
            /* One string solution
            var correctPasswordsCount = Enumerable
                .Range(min, max - min + 1)
                .AsParallel()
                .Select(n => n.ToString())
                .Where(s => s.SequenceEqual(s.OrderBy(ch => ch)))
                .Where(s => s.GroupBy(ch => ch).Any(g => g.Count() > 1))
                .Count(); */

            var correctPasswordsCount = Solver.GetCorrectPasswordsFromRangeType(min, max, Password.IsCorrectType1);
            Console.WriteLine($"Part1: {correctPasswordsCount}");
        }
        
        private static void SolvePart2(int min, int max)
        {
            /* One string solution
            var correctPasswordsCount = Enumerable
                .Range(min, max - min + 1)
                .AsParallel()
                .Select(n => n.ToString())
                .Where(s => s.SequenceEqual(s.OrderBy(ch => ch)))
                .Where(s => s.GroupBy(ch => ch).Any(g => g.Count() == 2))
                .Count(); */

            var correctPasswordsCount = Solver.GetCorrectPasswordsFromRangeType(min, max, Password.IsCorrectType2);
            Console.WriteLine($"Part2: {correctPasswordsCount}");
        }
    }
}