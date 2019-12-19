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

        private readonly Field _field;
        private readonly Droid _droid;

        public Solution()
        {
            _field = new Field();
            var program = Input.GetData()
                .Split(',')
                .Select(long.Parse)
                .ToArray();
            _droid = new Droid(_field, program);
        }

        public object SolvePart1()
        {
            BuildMap();
            return _droid.GetStepsCountBetween(new Vector2(0, 0), _field.OxygenPosition);
        }

        private void BuildMap()
        {
            _droid.BuildMap(() => {});
        }

        private void BuildMapWithImages()
        {
            var bounds = (new Vector2(-21, -21), new Vector2(19, 19));
            var step = 0;
            _droid.BuildMap(() =>
            {
                var filename = $"images/{step:D6}.png";
                Image.FromCells(_field.Cells, bounds,  16).Save(filename, ImageFormat.Png);
                Console.WriteLine(filename);
                step += 1;
            });
        }

        public object SolvePart2()
        {
            return null;
        }
    }
}