using System;
using System.Drawing.Imaging;
using System.Linq;
using Utils;

namespace Day_2019_12_15.App
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }

        public object SolvePart1()
        {
            var field = new Field();
            var program = Input.GetData()
                .Split(',')
                .Select(long.Parse)
                .ToArray();

            var droid = new Droid(field, program);
            var step = 0;
            var steps = droid.Explore(() =>
            {
                /*var filename = $"images/{step:D6}.png";
                Image.FromCells(field.Cells, 16).Save(filename, ImageFormat.Png);;
                Console.WriteLine(filename);
                step += 1;*/
            });
            
            return steps;
        }

        public object SolvePart2()
        {
            return null;
        }
    }
}