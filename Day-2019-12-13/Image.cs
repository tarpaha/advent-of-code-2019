using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace Day_2019_12_13
{
    public class Image
    {
        public static Bitmap FromScreen(Screen screen, int tileSize)
        {
            var tiles = screen.Tiles.ToList();
            var minX = tiles.Min(t => t.x);
            var maxX = tiles.Max(t => t.x);
            var minY = tiles.Min(t => t.y);
            var maxY = tiles.Max(t => t.y);
            
            var bitmap = new Bitmap(tileSize * (maxX - minX + 1), tileSize * (maxY - minY + 1), PixelFormat.Format24bppRgb);
            Graphics.FromImage(bitmap).Clear(Color.Black);
            foreach (var (x, y, id) in tiles)
            {
                DrawRectangle(bitmap, tileSize * (x - minX), tileSize * (y - minY), tileSize, id);
            }

            return bitmap;
        }

        private static void DrawRectangle(Bitmap bitmap, int x, int y, int size, int id)
        {
            using (var gr = Graphics.FromImage(bitmap))
            {
                gr.FillRectangle(GetBrush(id), x, y, size, size);
            }
        }

        private static Brush GetBrush(int id)
        {
            switch (id)
            {
                case 0:
                    return Brushes.Black;
                case 1:
                    return Brushes.RosyBrown;
                case 2:
                    return Brushes.Gray;
                case 3:
                    return Brushes.CornflowerBlue;
                case 4:
                    return Brushes.Orange;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}