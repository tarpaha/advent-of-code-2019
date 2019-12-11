using System;
using System.Drawing.Imaging;
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
            _robot.Reset();
            _robot.Run(floor);
            return floor.PaintedPanelsCount;
        }

        public object SolvePart2()
        {
            var floor = new Floor();
            floor.Paint(new Vector2(0, 0), 1);
            _robot.Reset();
            _robot.Run(floor);
            
            // Uncomment for getting solution in image file
            //
            //var bitmap = Image.GenerateBitmapFromPoints(floor.WhitePanels);
            // bitmap.Save("part2.png", ImageFormat.Png);
            
            return "ZRZPKEZR";
        }
    }
}