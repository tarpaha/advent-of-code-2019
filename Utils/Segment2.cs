using System;

namespace Utils
{
    public struct Segment2
    {
        public Vector2 P0;
        public Vector2 P1;

        public Segment2(int x0, int y0, int x1, int y1)
        {
            P0 = new Vector2(x0, y0);
            P1 = new Vector2(x1, y1);
        }

        public Segment2(Vector2 p0, Vector2 p1)
        {
            P0 = p0;
            P1 = p1;
        }

        public int Length =>
            P0.X == P1.X
                ? Math.Abs(P0.Y - P1.Y)
                : Math.Abs(P0.X - P1.X);

        public override string ToString()
        {
            return $"{P0}-{P1}";
        }
    }
}