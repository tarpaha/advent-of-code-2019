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
            _droid.BuildMap(() => {});
            // replace upper string with this to save each step to images folder
            //SaveImages("images_part1", action => {  _droid.BuildMap(action); return 0; });
            return _droid.GetStepsCountBetween(new Vector2(0, 0), _field.OxygenPosition);
        }

        public object SolvePart2()
        {
            return _droid.GetStepsToFloodAll(() => { });
            // replace upper string with this to save each step to images folder
            //return SaveImages("images_part2", action => _droid.GetStepsToFloodAll(action));
        }

        private int SaveImages(string folder, Func<Action, int> func)
        {
            var bounds = (new Vector2(-21, -21), new Vector2(19, 19));
            var step = 0;
            return func(() =>
            {
                var filename = $"{folder}/{step:D6}.png";
                Image.FromCells(_field.Cells, bounds,  16).Save(filename, ImageFormat.Png);
                Console.WriteLine(filename);
                step += 1;
            });
        }
    }
}