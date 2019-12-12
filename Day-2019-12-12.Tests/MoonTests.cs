using NUnit.Framework;
using Utils;

namespace Day_2019_12_12.Tests
{
    public class MoonTests
    {
        [Test]
        public void CreationTest()
        {
            var position = new Vector3(1, 2, 3);
            var moon = new Moon(position);
            Assert.That(moon.Position, Is.EqualTo(position));
            Assert.That(moon.Velocity, Is.EqualTo(new Vector3(0, 0, 0)));
        }

        [Test]
        public void UpdateVelocityTest()
        {
            var g = new Vector3(1, 2, 3);
            var moon = new Moon(new Vector3(0, 0, 0));
            moon.UpdateVelocity(g);
            moon.UpdateVelocity(g);
            Assert.That(moon.Velocity, Is.EqualTo(g + g));
        }

        [Test]
        public void UpdatePositionTest()
        {
            var p = new Vector3(10, 20, 30);
            var g = new Vector3(5, 6, 7);
            var moon = new Moon(p);
            
            moon.UpdateVelocity(g);
            Assert.That(moon.Position, Is.EqualTo(p));
            
            moon.UpdatePosition();
            Assert.That(moon.Position, Is.EqualTo(p + g));
            
            moon.UpdateVelocity(g);
            Assert.That(moon.Position, Is.EqualTo(p + g));
            
            moon.UpdatePosition();
            Assert.That(moon.Position, Is.EqualTo(p + g + g + g));
        }

        [Test]
        public void TotalEnergyTest()
        {
            var p = new Vector3(-10, 20, -30);
            var g = new Vector3(5, -6, 7);
            
            var moon = new Moon(p);
            moon.UpdateVelocity(g);
            
            Assert.That(moon.TotalEnergy, Is.EqualTo((10 + 20 + 30) * (5 + 6 + 7)));
        }
    }
}