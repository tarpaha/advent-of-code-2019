using System.Collections.Generic;
using NUnit.Framework;
using Utils;

namespace Day_2019_12_12.Tests
{
    public class ParserTests
    {
        private static IEnumerable<TestCaseData> ParserTestCases
        {
            get
            {
                yield return new TestCaseData("<x=1, y=2, z=3>", new[] { new Vector3(1, 2, 3) });
                yield return new TestCaseData("<x=1, y=2, z=3>|<x=-5, y=-6, z=-7>", new[] { new Vector3(1, 2, 3), new Vector3(-5, -6, -7) });
            }
        }
        
        [TestCaseSource("ParserTestCases")]
        public void Test(string data, Vector3[] points)
        {
            Assert.That(Parser.ParsePoints(data), Is.EquivalentTo(points));
        }
    }
}