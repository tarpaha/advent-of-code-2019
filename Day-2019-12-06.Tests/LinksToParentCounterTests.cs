using NUnit.Framework;

namespace Day_2019_12_06.Tests
{
    public class LinksToParentCounterTests
    {
        [TestCase("A)B", 1)]
        [TestCase("A)B,A)C", 2)]
        [TestCase("A)B,B)C", 3)]
        [TestCase("COM)B,B)C,C)D,D)E,E)F,B)G,G)H,D)I,E)J,J)K,K)L", 42)]
        public void Test(string recordsStr, int linksCount)
        {
            var planets = Parser.Parse(recordsStr.Split(","));
            Assert.That(LinksToParentCounter.Count(planets), Is.EqualTo(linksCount));
        }
    }
}