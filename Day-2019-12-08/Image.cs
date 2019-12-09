using System;
using System.Linq;

namespace Day_2019_12_08
{
    public class Image
    {
        public int Width { get; }
        public int Height { get; }
        public int LayersCount => _layers.Length;

        private readonly int[][] _layers;

        public Image(int[] data, int width, int height)
        {
            Width = width;
            Height = height;
            
            var layerSize = width * height;
            _layers = new int [data.Length / layerSize][];

            for (var layerIndex = 0; layerIndex < _layers.Length; layerIndex++)
            {
                _layers[layerIndex] = new int[layerSize];
                Array.Copy(data, layerIndex * layerSize, _layers[layerIndex], 0, layerSize);
            }
        }

        public int GetNumDigitsInLayer(int layerIndex, int digit)
        {
            var layer = _layers[layerIndex];
            return layer.Count(d => d == digit);
        }
    }
}