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
                .Select(long.Parse)
                .ToArray();
            
            _computer = new Computer();
            _computer.LoadProgram(program);
        }

        public object SolvePart1()
        {
            var output = new BufferOutput();
            _computer.Reset();
            _computer.AddInput(1);
            _computer.SetOutput(output);
            _computer.Run();
            return output.Data.Last();
        }

        public object SolvePart2()
        {
            var output = new BufferOutput();
            _computer.Reset();
            _computer.AddInput(5);
            _computer.SetOutput(output);
            _computer.Run();
            return output.Data.Last();
        }
    }
}