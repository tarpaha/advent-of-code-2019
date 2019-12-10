using System.Collections.Generic;
using System.Linq;

namespace Day_2019_12_10
{
    public static class Laser
    {
        private struct Record
        {
            public IAsteroid asteroid;
            public (int dx, int dy) distance;
            public int length;
            public float angle;
        }
        
        public static IAsteroid GetNthDestroyedAsteroid(int n, IAsteroid source, IEnumerable<IAsteroid> field)
        {
            var asteroids = field.Where(asteroid => asteroid != source).ToList();
            
            var records = new List<Record>();
            foreach (var asteroid in asteroids)
            {
                var (dx, dy, length) = Distance.Calculate(source, asteroid);
                var angle = Angle.Calculate(source, asteroid);
                records.Add(new Record
                {
                    distance = (dx, dy),
                    length = length,
                    angle = angle,
                    asteroid = asteroid
                });
            }

            records = records.OrderBy(r => r.angle).ToList();
            
            var currentAngle = 0f;
            IAsteroid lastDestroyedAsteroid = null;
            while (n > 0)
            {
                var closest = records
                    .First(r => r.angle >= currentAngle);

                var recordsOnLine = records.Where(r => r.distance == closest.distance).ToList();
                var closestOnLine = recordsOnLine.OrderBy(r => r.length).First();

                records.Remove(closestOnLine);
                lastDestroyedAsteroid = closestOnLine.asteroid;

                var next = records.Where(r => r.angle > currentAngle).ToList();
                currentAngle = next.Any()
                    ? next.First().angle
                    : 0;

                n -= 1;
            }
            
            return lastDestroyedAsteroid;
        }
    }
}