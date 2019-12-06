using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_06.Tests
{
    public class ParserTests
    {
        [TestCase("A)B")]
        [TestCase("A)B,A)C")]
        [TestCase("A)B,B)C")]
        public void Test(string recordsStr)
        {
            var records = recordsStr.Split(",");
            var planets = Parser.Parse(records).ToDictionary(p => p.Name, p => p);
            foreach (var record in records)
            {
                var pair = record.Split(")");
                var (parentName, childName) = (pair[0], pair[1]);
                Assert.That(planets[childName].Parent, Is.EqualTo(planets[parentName]));
                Assert.That(planets[parentName].Children.Count(p => p == planets[childName]), Is.EqualTo(1));
            }
        }
    }
}