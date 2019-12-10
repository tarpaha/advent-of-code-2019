using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_10.Tests
{
    public class ReaderTests
    {
        [TestCase("..A|B.C", new [] { "A", "B", "C" }, new [] { 2, 0, 0, 1, 2, 1 })]
        public void Test(string data, string[] names, int[] coords)
        { 
            var asteroids = Reader.Read(data).ToArray();
            Assert.That(asteroids.Length, Is.EqualTo(names.Length));
            for (var i = 0; i < asteroids.Length; i++)
            {
                Assert.That(asteroids[i].Name, Is.EqualTo(names[i]));
                Assert.That(asteroids[i].X, Is.EqualTo(coords[2 * i]));
                Assert.That(asteroids[i].Y, Is.EqualTo(coords[2 * i + 1]));
            }
        }
    }
}