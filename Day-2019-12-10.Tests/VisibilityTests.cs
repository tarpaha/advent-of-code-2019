using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_10.Tests
{
    public class VisibilityTests
    {
        [TestCase("121")]
        [TestCase("33|33")]
        [TestCase("575|787|575")]
        [TestCase(".7..7|.....|67775|....7|...87")]
        public void Test(string data)
        {
            var planets = Reader.Read(data).ToList();
            foreach (var planet in planets)
            {
                var visibleCount = Visibility.VisibleCount(planet, planets); 
                Assert.That(visibleCount.ToString(), Is.EqualTo(planet.Name));
            }
        }
    }
}