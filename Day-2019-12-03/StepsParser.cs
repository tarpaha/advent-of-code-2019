using System.Collections.Generic;
using Utils;

namespace Day_2019_12_03
{
    public static class StepsParser
    {
        public static IEnumerable<Segment2> Parse(string stepsStr)
        {
            var segments = new List<Segment2>();
            var currentPosition = new Vector2(0, 0);
            foreach (var step in stepsStr.Split(','))
            {
                var newPosition = Move(currentPosition, step);
                segments.Add(new Segment2(currentPosition, newPosition));
                currentPosition = newPosition;
            }
            return segments;
        }

        private static Vector2 Move(Vector2 pos, string step)
        {
            var direction = step[0];
            var distance = int.Parse(step.Substring(1));
            switch (direction)
            {
                case 'U':
                    pos.Y += distance;
                    break;
                case 'D':
                    pos.Y -= distance;
                    break;
                case 'L':
                    pos.X -= distance;
                    break;
                case 'R':
                    pos.X += distance;
                    break;
            }
            return pos;
        }
    }
}