using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_10.Tests
{
    public class ReaderTests
    {
        [TestCase("..#|...", "#", 2, 0)]
        public void Test(string data, string name, int x, int y)
        {
            var planets = Reader.Read(data).ToList();
            Assert.That(planets.Count, Is.EqualTo(1));
            var planet = planets.First();
            Assert.That(planet.Name, Is.EqualTo(name));
            Assert.That(planet.X, Is.EqualTo(x));
            Assert.That(planet.Y, Is.EqualTo(y));
        }
    }
}