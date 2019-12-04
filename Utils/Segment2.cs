using System;

namespace Utils
{
    public struct Segment2
    {
        public Vector2 p0;
        public Vector2 p1;

        public Segment2(int x0, int y0, int x1, int y1)
        {
            p0 = new Vector2(x0, y0);
            p1 = new Vector2(x1, y1);
        }

        public Segment2(Vector2 p0, Vector2 p1)
        {
            this.p0 = p0;
            this.p1 = p1;
        }

        public int Length =>
            p0.x == p1.x
                ? Math.Abs(p0.y - p1.y)
                : Math.Abs(p0.x - p1.x);

        public override string ToString()
        {
            return $"{p0}-{p1}";
        }
    }
}