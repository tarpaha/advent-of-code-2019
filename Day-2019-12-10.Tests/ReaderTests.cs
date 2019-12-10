using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_10.Tests
{
    public class ReaderTests
    {
        [TestCase("..A|B.C", new [] { "A", "B", "C" }, new [] { 2, 0, 0, 1, 2, 1 })]
        public void Test(string data, string[] names, int[] coords)
        { 
            var planets = Reader.Read(data).ToArray();
            Assert.That(planets.Length, Is.EqualTo(names.Length));
            for (var i = 0; i < planets.Length; i++)
            {
                Assert.That(planets[i].Name, Is.EqualTo(names[i]));
                Assert.That(planets[i].X, Is.EqualTo(coords[2 * i]));
                Assert.That(planets[i].Y, Is.EqualTo(coords[2 * i + 1]));
            }
        }
    }
}