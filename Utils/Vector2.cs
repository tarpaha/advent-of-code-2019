using System;

namespace Utils
{
    public struct Vector2
    {
        public int X;
        public int Y;

        public int Manhattan => Math.Abs(X) + Math.Abs(Y); 
        
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}