using System.Collections.Generic;
using NUnit.Framework;

namespace Utils.Tests
{
    public class Vector3Tests
    {
        private static IEnumerable<TestCaseData> OperatorUnaryPlusTestCases
        {
            get
            {
                yield return new TestCaseData(new Vector3(0, 0, 0));
                yield return new TestCaseData(new Vector3(1, 2, 3));
                yield return new TestCaseData(new Vector3(-4, -5, -6));
            }
        }
        
        private static IEnumerable<TestCaseData> OperatorUnaryMinusTestCases
        {
            get
            {
                yield return new TestCaseData(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                yield return new TestCaseData(new Vector3(1, 2, 3), new Vector3(-1, -2, -3));
                yield return new TestCaseData(new Vector3(-4, -5, -6), new Vector3(4, 5, 6));
            }
        }
        
        private static IEnumerable<TestCaseData> OperatorPlusTestCases
        {
            get
            {
                yield return new TestCaseData(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                yield return new TestCaseData(new Vector3(1, 2, 3), new Vector3(-3, -2, -1), new Vector3(-2, 0, 2));
            }
        }
        
        private static IEnumerable<TestCaseData> OperatorMinusTestCases
        {
            get
            {
                yield return new TestCaseData(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                yield return new TestCaseData(new Vector3(1, 2, 3), new Vector3(-3, -2, -1), new Vector3(4, 4, 4));
            }
        }

        [TestCaseSource("OperatorUnaryPlusTestCases")]
        public void UnaryPlusTests(Vector3 a)
        {
            Assert.That(+a, Is.EqualTo(a));
        }
        
        [TestCaseSource("OperatorUnaryMinusTestCases")]
        public void UnaryMinusTests(Vector3 a, Vector3 b)
        {
            Assert.That(-a, Is.EqualTo(b));
        }
        
        [TestCaseSource("OperatorPlusTestCases")]
        public void PlusTests(Vector3 a, Vector3 b, Vector3 c)
        {
            Assert.That(a + b, Is.EqualTo(c));
        }
        
        [TestCaseSource("OperatorMinusTestCases")]
        public void MinusTests(Vector3 a, Vector3 b, Vector3 c)
        {
            Assert.That(a - b, Is.EqualTo(c));
        }
    }
}