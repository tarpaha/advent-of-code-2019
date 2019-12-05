using System;
using System.IO;
using System.Linq;

namespace Day_2019_12_05.App
{
    public static class Program
    {
        public static void Main()
        {
            var program = File
                .ReadAllText("data/input.txt")
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            
            var computer = new Computer();
            computer.LoadProgram(program);

            SolvePart1(computer);
            SolvePart2(computer);
        }

        private static void SolvePart1(Computer computer)
        {
            computer.RestoreMemory();
            computer.SetInput(new[] {1});
            computer.Execute();
            Console.WriteLine($"Part1: {computer.GetOutput().Last()}");
        }
        
        private static void SolvePart2(Computer computer)
        {
            computer.RestoreMemory();
            computer.SetInput(new[] {5});
            computer.Execute();
            Console.WriteLine($"Part2: {computer.GetOutput().Last()}");
        }
    }
}