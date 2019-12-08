using System;
using Utils;
//using System.Linq;

namespace Day_2019_12_04.App
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }
        
        private readonly int _min;
        private readonly int _max;

        public Solution()
        {
            _min = 124075;
            _max = 580769;
        }

        public int SolvePart1()
        {
            /* One string solution
            Enumerable
                .Range(min, max - min + 1)
                .AsParallel()
                .Select(n => n.ToString())
                .Where(s => s.SequenceEqual(s.OrderBy(ch => ch)))
                .Where(s => s.GroupBy(ch => ch).Any(g => g.Count() > 1))
                .Count(); */
            return Solver.GetCorrectPasswordsFromRangeType(_min, _max, Password.IsCorrectType1);
        }

        public int SolvePart2()
        {
            /* One string solution
            Enumerable
                .Range(min, max - min + 1)
                .AsParallel()
                .Select(n => n.ToString())
                .Where(s => s.SequenceEqual(s.OrderBy(ch => ch)))
                .Where(s => s.GroupBy(ch => ch).Any(g => g.Count() == 2))
                .Count(); */
            return Solver.GetCorrectPasswordsFromRangeType(_min, _max, Password.IsCorrectType2);
        }
    }
}