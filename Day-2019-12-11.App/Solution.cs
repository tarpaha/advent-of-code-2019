using System;
using System.Linq;
using Utils;
using Utils.Computer;

namespace Day_2019_12_11.App
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }
        
        private readonly Robot _robot;

        public Solution()
        {
            var program = Input.GetData()
                .Split(',')
                .Select(long.Parse)
                .ToArray();
            
            var computer = new IntCodeComputer();
            computer.LoadProgram(program);

            _robot = new Robot(computer);
        }

        public object SolvePart1()
        {
            var floor = new Floor();
            _robot.Run(floor);
            return floor.PaintedPanelsCount;
        }

        public object SolvePart2()
        {
            return null;
        }
    }
}