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
            
            var computer = new Computer();
            computer.LoadProgram(input);
            
            SolvePart1(computer);
            SolvePart2(computer);
        }

        private static void SolvePart1(Computer computer)
        {
            computer.RestoreMemory();
            computer.SetMemory(1, 12);
            computer.SetMemory(2, 2);
            computer.Execute();
            Console.WriteLine($"Part1: {computer.GetMemory(0)}");
        }

        private static void SolvePart2(Computer computer)
        {
            for (var noun = 0; noun < 100; noun++)
            {
                for (var verb = 0; verb < 100; verb++)
                {
                    computer.RestoreMemory();
                    computer.SetMemory(1, noun);
                    computer.SetMemory(2, verb);
                    computer.Execute();
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