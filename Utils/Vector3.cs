﻿namespace Utils
{
    public struct Vector3
    {
        public int x;
        public int y;
        public int z;

        public Vector3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }

        public static Vector3 operator +(Vector3 a)
        {
            return new Vector3(a.x, a.y, a.z);
        }
        
        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a.x, -a.y, -a.z);
        }
        
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return a + -b;
        }

        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }

        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return !(a == b);
        }
    }
}