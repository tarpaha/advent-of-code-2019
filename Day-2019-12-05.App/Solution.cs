using System;
using System.Linq;
using Utils;

namespace Day_2019_12_05.App
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }
        
        private readonly Computer _computer;

        public Solution()
        {
            var program = Input.GetData()
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            
            _computer = new Computer();
            _computer.LoadProgram(program);
        }

        public int SolvePart1()
        {
            _computer.RestoreMemory();
            _computer.SetInput(new[] {1});
            _computer.Execute();
            return _computer.GetOutput().Last();
        }

        public int SolvePart2()
        {
            _computer.RestoreMemory();
            _computer.SetInput(new[] {5});
            _computer.Execute();
            return _computer.GetOutput().Last();
        }
    }
}