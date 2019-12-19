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
        public static Bitmap FromCells(IEnumerable<(Vector2 pos, int state)> cellsCollection, int tileSize)
        {
            var cells = cellsCollection.ToList();
            var minX = cells.Min(t => t.pos.x);
            var maxX = cells.Max(t => t.pos.x);
            var minY = cells.Min(t => t.pos.y);
            var maxY = cells.Max(t => t.pos.y);
            
            var bitmap = new Bitmap(tileSize * (maxX - minX + 1), tileSize * (maxY - minY + 1), PixelFormat.Format24bppRgb);
            Graphics.FromImage(bitmap).Clear(Color.Black);
            foreach (var (pos, state) in cells)
            {
                DrawRectangle(bitmap, tileSize * (pos.x - minX), tileSize * (pos.y - minY), tileSize, state);
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
                    return Brushes.Green;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}