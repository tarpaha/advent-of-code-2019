using System;
using System.Linq;
using Utils;

namespace Day_2019_12_02.App
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

        public object SolvePart1()
        {
            _computer.Reset();
            _computer.SetMemory(1, 12);
            _computer.SetMemory(2, 2);
            _computer.Run();
            return _computer.GetMemory(0);
        }

        public object SolvePart2()
        {
            for (var noun = 0; noun < 100; noun++)
            {
                for (var verb = 0; verb < 100; verb++)
                {
                    _computer.Reset();
                    _computer.SetMemory(1, noun);
                    _computer.SetMemory(2, verb);
                    _computer.Run();
                    if (_computer.GetMemory(0) == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                }
            }
            throw new Exception();
        }

        private static void SolvePart1(Computer computer)
        {
            computer.Reset();
            computer.SetMemory(1, 12);
            computer.SetMemory(2, 2);
            computer.Run();
            Console.WriteLine($"Part1: {computer.GetMemory(0)}");
        }

        private static void SolvePart2(Computer computer)
        {
            for (var noun = 0; noun < 100; noun++)
            {
                for (var verb = 0; verb < 100; verb++)
                {
                    computer.Reset();
                    computer.SetMemory(1, noun);
                    computer.SetMemory(2, verb);
                    computer.Run();
                    if (computer.GetMemory(0) == 19690720)
                    {
                        Console.WriteLine($"Part2: {100 * noun + verb}");
                        return;
                    }
                }
            }
        }
    }
}