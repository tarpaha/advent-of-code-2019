using System;
using System.IO;
using System.Linq;

namespace Day_2019_12_02.App
{
    public static class Program
    {
        public static void Main()
        {
            var input = File
                .ReadAllText("data/input.txt")
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            
            SolvePart1(input);
            SolvePart2(input);
        }

        private static void SolvePart1(int[] input)
        {
            var program = new int[input.Length];
            Array.Copy(input, program, input.Length);
            program[1] = 12;
            program[2] = 2;
            Computer.Compute(program);
            Console.WriteLine($"Part1: {program[0]}");
        }

        private static void SolvePart2(int[] input)
        {
            var program = new int[input.Length];
            for (var noun = 0; noun < 100; noun++)
            {
                for (var verb = 0; verb < 100; verb++)
                {
                    Array.Copy(input, program, input.Length);
                    program[1] = noun;
                    program[2] = verb;
                    Computer.Compute(program);
                    if (program[0] == 19690720)
                    {
                        Console.WriteLine($"Part2: {100 * noun + verb}");
                        return;
                    }
                }
            }
        }
    }
}