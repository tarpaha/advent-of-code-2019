using System.Collections.Generic;
using NUnit.Framework;
using Utils;

namespace Day_2019_12_03.Tests
{
    public class StepsParserTests
    {
        private static IEnumerable<TestCaseData> StepsParserTestCases
        {
            get
            {
                yield return new TestCaseData("R1", new [] { new Segment2(0, 0, +1, 0) });
                yield return new TestCaseData("L1", new [] { new Segment2(0, 0, -1, 0) });
                yield return new TestCaseData("U1", new [] { new Segment2(0, 0, 0, +1) });
                yield return new TestCaseData("D1", new [] { new Segment2(0, 0, 0, -1) });
                yield return new TestCaseData("R8,U5,L5,D3", new []
                {
                    new Segment2(0, 0, 8, 0),
                    new Segment2(8, 0, 8, 5),
                    new Segment2(8, 5, 3, 5),
                    new Segment2(3, 5, 3, 2)
                });
            }
        }

        [TestCaseSource("StepsParserTestCases")]
        public void Test(string steps, IEnumerable<Segment2> segments)
        {
            Assert.That(StepsParser.Parse(steps), Is.EquivalentTo(segments));
        }
    }
}