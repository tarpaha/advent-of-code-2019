using System;

namespace Day_2019_12_10
{
    public static class Angle
    {
        // angle from source-up to source-target, clockwise 0...360
        public static float Calculate(IAsteroid source, IAsteroid target)
        {
            var vx = target.X - source.X;
            var vy = target.Y - source.Y;
            var angle = Math.Atan2(vx, -vy) * 180.0 / Math.PI;
            return (float) (angle < 0 ? angle + 360 : angle);
        }
    }
}