
using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_10.Tests
{
    public class DistanceTests
    {
        [TestCase("ABC|DEF|GHI", "A", "B", +1,  0, 1)]
        [TestCase("ABC|DEF|GHI", "A", "C", +1,  0, 2)]
        [TestCase("ABC|DEF|GHI", "C", "A", -1,  0, 2)]
        [TestCase("ABC|DEF|GHI", "A", "F", +2, +1, 1)]
        [TestCase("ABC|DEF|GHI", "A", "E", +1, +1, 1)]
        [TestCase("ABC|DEF|GHI", "A", "I", +1, +1, 2)]
        [TestCase("ABC|DEF|GHI", "C", "G", -1, +1, 2)]
        [TestCase("ABC|DEF|GHI", "G", "C", +1, -1, 2)]
        [TestCase("ABC|DEF|GHI", "I", "A", -1, -1, 2)]
        public void Test(string data, string asteroid1Name, string asteroid2Name, int dx, int dy, int length)
        {
            var asteroids = Reader.Read(data).ToList();
            var asteroid1 = asteroids.First(a => a.Name == asteroid1Name);
            var asteroid2 = asteroids.First(a => a.Name == asteroid2Name);
            Assert.That(Distance.Calculate(asteroid1, asteroid2), Is.EqualTo((dx, dy, length)));
        }
    }
}