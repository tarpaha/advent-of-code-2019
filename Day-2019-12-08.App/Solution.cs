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

        private readonly int _width; 
        private readonly int _height; 
        private readonly Image _image;

        public Solution()
        {
            var data = Input.GetData()
                .Select(ch => ch - '0')
                .ToArray();
            _width = 25;
            _height = 6;
            _image = new Image(data, _width, _height);
        }

        public object SolvePart1()
        {
            var layerWithMinZeros = Enumerable.Range(0, _image.LayersCount)
                .Select(id => (id, _image.GetNumDigitsInLayer(id, 0)))
                .OrderBy(pair => pair.Item2)
                .First().Item1;

            return _image.GetNumDigitsInLayer(layerWithMinZeros, 1) * _image.GetNumDigitsInLayer(layerWithMinZeros, 2);
        }

        public object SolvePart2()
        {
            var visible = _image.GetVisibleImage();
            return string.Join("", visible);
        }
    }
}