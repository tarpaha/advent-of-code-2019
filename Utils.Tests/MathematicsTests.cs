using NUnit.Framework;

namespace Utils.Tests
{
    public class MathematicsTests
    {
        [TestCase(1, 2, 1, 2, 1)]
        [TestCase(2, 4, 1, 2, 2)]
        [TestCase(-9, -3, -3, -1, 3)]
        [TestCase(-12, 20, -3, 5, 4)]
        [TestCase(20, -5, 4, -1, 5)]
        [TestCase(0, 10, 0, 1, 10)]
        [TestCase(-10, 0, -1, 0, 10)]
        public void ReduceFractionTests(int a1, int b1, int a2, int b2, int n)
        {
            Assert.That(Mathematics.ReduceFraction(a1, b1), Is.EqualTo((a2, b2, n)));
        }
    }
}