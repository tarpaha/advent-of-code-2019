using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Utils;

namespace Day_2019_12_15
{
    public class Image
    {
        public static Bitmap FromCells(IEnumerable<(Vector2 pos, int state)> cells, (Vector2 min, Vector2 max) bounds,
            int tileSize)
        {
            var bitmap = new Bitmap(
                tileSize * (bounds.max.x - bounds.min.x + 1),
                tileSize * (bounds.max.y - bounds.min.y + 1),
                PixelFormat.Format24bppRgb);
            Graphics.FromImage(bitmap).Clear(Color.Black);
            foreach (var (pos, state) in cells)
            {
                DrawRectangle(bitmap, tileSize * (pos.x - bounds.min.x), tileSize * (pos.y - bounds.min.y), tileSize, state);
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

        private static Brush GetBrush(int state)
        {
            switch (state)
            {
                case 0:
                    return Brushes.Brown;
                case 1:
                    return Brushes.Gray;
                case 2:
                    return Brushes.SkyBlue;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}