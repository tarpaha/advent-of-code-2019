using System.Collections.Generic;
using NUnit.Framework;

namespace Utils.Tests
{
    public class Vector2Tests
    {
        private static IEnumerable<TestCaseData> ManhattanTestCases
        {
            get
            {
                yield return new TestCaseData(new Vector2(0, 0), 0);
                yield return new TestCaseData(new Vector2(+1, +1), 2);
                yield return new TestCaseData(new Vector2(-1, +1), 2);
                yield return new TestCaseData(new Vector2(+1, -1), 2);
                yield return new TestCaseData(new Vector2(-1, -1), 2);
            }
        }

        [TestCaseSource("ManhattanTestCases")]
        public void TestIntersect(Vector2 v, int manhattan)
        {
            Assert.That(v.Manhattan, Is.EqualTo(manhattan));
        }
    }
}