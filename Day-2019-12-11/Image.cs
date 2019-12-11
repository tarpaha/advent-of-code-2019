using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Utils;

namespace Day_2019_12_11
{
    public static class Image
    {
        public static Bitmap GenerateBitmapFromPoints(IEnumerable<Vector2> pointsCollection)
        {
            var points = pointsCollection.ToList();
            
            var minX = points.Select(p => p.x).Min();
            var maxX = points.Select(p => p.x).Max();
            var minY = points.Select(p => p.y).Min();
            var maxY = points.Select(p => p.y).Max();

            var bitmap = new Bitmap(maxX - minX + 1, maxY - minY + 1, PixelFormat.Format24bppRgb);
            
            Graphics.FromImage(bitmap).Clear(Color.Black);
            foreach (var point in points)
            {
                bitmap.SetPixel(point.x - minX, point.y - minY, Color.White);
            }

            return bitmap;
        }
    }
}