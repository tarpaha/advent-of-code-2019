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

        public int[] GetVisibleImage()
        {
            var data = new int[Width * Height];
            for(var y = 0; y < Height; y++)
                for (var x = 0; x < Width; x++)
                    data[x + y * Width] = GetVisiblePixel(x, y);
            return data;
        }

        private int GetVisiblePixel(int x, int y)
        {
            var visiblePixel = 2;
            for (var layerIndex = _layers.Length - 1; layerIndex >= 0; layerIndex--)
            {
                var pixel = GetLayerPixel(layerIndex, x, y);
                if (pixel != 2)
                    visiblePixel = pixel;
            }
            return visiblePixel;
        }

        private int GetLayerPixel(int layerIndex, int x, int y)
        {
            return _layers[layerIndex][x + y * Width];
        }
    }
}