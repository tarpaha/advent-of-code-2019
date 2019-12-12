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
    }
}