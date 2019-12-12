using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_2019_12_12
{
    public class Space
    {
        private readonly IList<Moon> _moons;

        public IEnumerable<Moon> Moons => _moons;
        public int TotalEnergy => _moons.Select(moon => moon.TotalEnergy).Sum();

        public Space(IEnumerable<Vector3> moonPositions)
        {
            _moons = moonPositions.Select(pos => new Moon(pos)).ToList();
        }

        public void Step()
        {
            for(var i = 0; i < _moons.Count(); i++)
                for(var j = i+1; j < _moons.Count(); j++)
                    UpdateVelocities(_moons[i], _moons[j]);
            foreach (var moon in _moons)
                moon.UpdatePosition();
        }

        public long GetRepeatPeriod()
        {
            var moonPositions = _moons.Select(m => m.Position).ToArray();
            var repeatPeriods = new[]
            {
                GetCoordinateRepeatPeriod(moonPositions.Select(p => p.x).ToArray()),
                GetCoordinateRepeatPeriod(moonPositions.Select(p => p.y).ToArray()),
                GetCoordinateRepeatPeriod(moonPositions.Select(p => p.z).ToArray())
            };
            return Mathematics.LeastCommonMultiple(repeatPeriods);
        }
        
        private void UpdateVelocities(Moon moon1, Moon moon2)
        {
            var distance = moon2.Position - moon1.Position;
            var g = new Vector3(
                Mathematics.Sign(distance.x),
                Mathematics.Sign(distance.y),
                Mathematics.Sign(distance.z));
            moon1.UpdateVelocity(+g);
            moon2.UpdateVelocity(-g);
        }

        private static long GetCoordinateRepeatPeriod(int[] p)
        {
            var initial = new int[p.Length];
            Array.Copy(p, initial, p.Length);

            var v = new int[p.Length];
            
            long step = 0;
            while(true)
            {
                for(var i = 0; i < p.Length; i++)
                for (var j = i + 1; j < p.Length; j++)
                {
                    if (p[i] < p[j])
                    {
                        v[i] += 1;
                        v[j] -= 1;
                    }
                    else if (p[i] > p[j])
                    {
                        v[i] -= 1;
                        v[j] += 1;
                    }
                }

                for (var i = 0; i < p.Length; i++)
                    p[i] += v[i];

                step += 1;

                var rest = true;
                for (var i = 0; rest && i < v.Length; i++)
                    rest &= v[i] == 0;

                if (rest)
                {
                    var samePosition = true;
                    for (var i = 0; samePosition && i < initial.Length; i++)
                        samePosition &= initial[i] == p[i];
                    
                    if (samePosition)
                        break;
                }
            }
            
            return step;
        }
    }
}