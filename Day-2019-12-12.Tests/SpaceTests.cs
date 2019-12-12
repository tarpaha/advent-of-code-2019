using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_12.Tests
{
    public class SpaceTests
    {
        [TestCase("<x=-1, y=0, z=2>|<x=2, y=-10, z=-7>|<x=4, y=-8, z=8>|<x=3, y=5, z=-1>", 0, "<x=-1, y=0, z=2>|<x=2, y=-10, z=-7>|<x=4, y=-8, z=8>|<x=3, y=5, z=-1>", "<x= 0, y= 0, z= 0>|<x= 0, y= 0, z= 0>|<x= 0, y= 0, z= 0>|<x= 0, y= 0, z= 0>")]
        [TestCase("<x=-1, y=0, z=2>|<x=2, y=-10, z=-7>|<x=4, y=-8, z=8>|<x=3, y=5, z=-1>", 1, "<x= 2, y=-1, z= 1>|<x= 3, y=-7, z=-4>|<x= 1, y=-7, z= 5>|<x= 2, y= 2, z= 0>", "<x= 3, y=-1, z=-1>|<x= 1, y= 3, z= 3>|<x=-3, y= 1, z=-3>|<x=-1, y=-3, z= 1>")]
        [TestCase("<x=-1, y=0, z=2>|<x=2, y=-10, z=-7>|<x=4, y=-8, z=8>|<x=3, y=5, z=-1>", 10, "<x= 2, y= 1, z=-3>|<x= 1, y=-8, z= 0>|<x= 3, y=-6, z= 1>|<x= 2, y= 0, z= 4>", "<x=-3, y=-2, z= 1>|<x=-1, y= 1, z= 3>|<x= 3, y= 2, z=-3>|<x= 1, y=-1, z=-1>")]
        public void StepTest(string initialPositions, int steps, string positions, string velocities)
        {
            var points = Parser.ParsePoints(initialPositions);
            var space = new Space(points);
            for(var i = 0; i < steps; i++)
                space.Step();
            Assert.That(space.Moons.Select(m => m.Position), Is.EquivalentTo(Parser.ParsePoints(positions)));
            Assert.That(space.Moons.Select(m => m.Velocity), Is.EquivalentTo(Parser.ParsePoints(velocities)));
        }

        [TestCase("<x=-1, y=0, z=2>|<x=2, y=-10, z=-7>|<x=4, y=-8, z=8>|<x=3, y=5, z=-1>", 10, 179)]
        [TestCase("<x=-8, y=-10, z=0>|<x=5, y=5, z=10>|<x=2, y=-7, z=3>|<x=9, y=-8, z=-3>", 100, 1940)]
        public void TotalEnergyTest(string data, int steps, int totalEnergy)
        {
            var space = new Space(Parser.ParsePoints(data));
            for(var i = 0; i < steps; i++)
                space.Step();
            Assert.That(space.TotalEnergy, Is.EqualTo(totalEnergy));
        }
        
        [TestCase("<x=-1, y=0, z=2>|<x=2, y=-10, z=-7>|<x=4, y=-8, z=8>|<x=3, y=5, z=-1>", 2772L)]
        [TestCase("<x=-8, y=-10, z=0>|<x=5, y=5, z=10>|<x=2, y=-7, z=3>|<x=9, y=-8, z=-3>", 4686774924L)]
        public void GetRepeatPeriodTest(string data, long repeatPeriod)
        {
            var space = new Space(Parser.ParsePoints(data));
            Assert.That(space.GetRepeatPeriod(), Is.EqualTo(repeatPeriod));
        }
    }
}