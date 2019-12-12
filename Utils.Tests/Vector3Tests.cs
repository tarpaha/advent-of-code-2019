using System.Collections.Generic;
using NUnit.Framework;

namespace Utils.Tests
{
    public class Vector3Tests
    {
        private static IEnumerable<TestCaseData> OperatorPlusTestCases
        {
            get
            {
                yield return new TestCaseData(new Vector3(1, 2, 3), new Vector3(-3, -2, -1), new Vector3(-2, 0, 2));
            }
        }

        [TestCaseSource("OperatorPlusTestCases")]
        public void Test(Vector3 a, Vector3 b, Vector3 c)
        {
            Assert.That(a + b, Is.EqualTo(c));
        }
    }
}