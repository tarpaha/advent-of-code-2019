using System;

namespace Utils
{
    public struct Vector2
    {
        public int x;
        public int y;

        public int Manhattan => Math.Abs(x) + Math.Abs(y); 
        
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public int SqrDist(Vector2 p)
        {
            var dx = p.x - x;
            var dy = p.y - y;
            return dx * dx + dy * dy;
        }

        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !(a == b);
        }
    }
}