using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_2019_12_08.App
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }

        private readonly int[] _data;
        private readonly Image _image;

        public Solution()
        {
            var data = Input.GetData()
                .Select(ch => ch - '0')
                .ToArray();
            _image = new Image(data, 25, 6);
        }

        public int SolvePart1()
        {
            var layerWithMinZeros = Enumerable.Range(0, _image.LayersCount)
                .Select(id => (id, num: _image.GetNumDigitsInLayer(id, 0)))
                .OrderBy(pair => pair.num)
                .First().id;

            return _image.GetNumDigitsInLayer(layerWithMinZeros, 1) * _image.GetNumDigitsInLayer(layerWithMinZeros, 2);
        }

        public int SolvePart2()
        {
            return 0;
        }
    }
}