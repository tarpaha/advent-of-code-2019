using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_10.Tests
{
    public class AngleTests
    {
        [TestCase(".B.|.A.|...", 0.0f)]
        [TestCase("..B|.A.|...", 45.0f)]
        [TestCase("...|.AB|...", 90.0f)]
        [TestCase("...|.A.|..B", 135.0f)]
        [TestCase("...|.A.|.B.", 180.0f)]
        [TestCase("...|.A.|B..", 225.0f)]
        [TestCase("...|BA.|...", 270.0f)]
        [TestCase("B..|.A.|...", 315.0f)]
        public void Test(string data, float angle)
        {
            var planets = Reader.Read(data).ToList();
            var planetA = planets.First(planet => planet.Name == "A");
            var planetB = planets.First(planet => planet.Name == "B");
            Assert.That(Angle.Calculate(planetA, planetB), Is.EqualTo(angle));
        }
    }
}