using System.Collections.Generic;
using NUnit.Framework;

namespace Utils.Tests
{
    public class Segment2Tests
    {
        private static IEnumerable<TestCaseData> LengthTestCases
        {
            get
            {
                yield return new TestCaseData(new Segment2(0, 0, +1, 0), 1);
                yield return new TestCaseData(new Segment2(0, 0, -1, 0), 1);
                yield return new TestCaseData(new Segment2(0, -1, 0, 0), 1);
                yield return new TestCaseData(new Segment2(0, 0, 0, +1), 1);
                yield return new TestCaseData(new Segment2(0, 1, 0, -1), 2);
                yield return new TestCaseData(new Segment2(1, 0, -1, 0), 2);
            }
        }

        [TestCaseSource("LengthTestCases")]
        public void TestLength(Segment2 s, int length)
        {
            Assert.That(s.Length, Is.EqualTo(length));
        }
    }
}