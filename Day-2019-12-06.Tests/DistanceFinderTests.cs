using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_06.Tests
{
    public class DistanceFinderTests
    {
        [TestCase("A)B", "B", "A")]
        [TestCase("A)B,B)C", "C", "A,B")]
        public void GetPathFromRootTest(string recordsStr, string planetName, string pathStr)
        {
            var planets = Parser.Parse(recordsStr.Split(","));
            var planet = planets.First(p => p.Name == planetName);
            var path = DistanceFinder.GetPathFromRoot(planet);
            Assert.That(string.Join(",", path.Select(p => p.Name)), Is.EqualTo(pathStr));
        }

        [TestCase("A)B,B)C", "B", "A", 0)]
        [TestCase("A)B,B)C", "C", "A", 1)]
        [TestCase("COM)B,B)C,C)D,D)E,E)F,B)G,G)H,D)I,E)J,J)K,K)L,K)YOU,I)SAN", "YOU", "D", 3)]
        [TestCase("COM)B,B)C,C)D,D)E,E)F,B)G,G)H,D)I,E)J,J)K,K)L,K)YOU,I)SAN", "SAN", "D", 1)]
        public void GetDistanceToParentTest(string recordsStr, string planetName, string parentName, int distance)
        {
            var planets = Parser.Parse(recordsStr.Split(","));
            var parent = planets.First(p => p.Name == parentName);
            var planet = planets.First(p => p.Name == planetName);
            Assert.That(DistanceFinder.GetDistanceToParent(planet, parent), Is.EqualTo(distance));
        }
        
        [TestCase("A)B,B)C,A)D", "C", "D", 1)]
        [TestCase("COM)B,B)C,C)D,D)E,E)F,B)G,G)H,D)I,E)J,J)K,K)L,K)YOU,I)SAN", "YOU", "SAN", 4)]
        public void GetDistanceBetweenTest(string recordsStr, string planet1Name, string planet2Name, int distance)
        {
            var planets = Parser.Parse(recordsStr.Split(","));
            var planet1 = planets.First(p => p.Name == planet1Name);
            var planet2 = planets.First(p => p.Name == planet2Name);
            Assert.That(DistanceFinder.GetDistanceBetween(planet1, planet2), Is.EqualTo(distance));
        }
    }
}