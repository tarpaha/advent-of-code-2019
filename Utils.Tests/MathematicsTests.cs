﻿using NUnit.Framework;

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

        [TestCase(-2, -1)]
        [TestCase(-1, -1)]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        public void SignTests(int v, int sign)
        {
            Assert.That(Mathematics.Sign(v), Is.EqualTo(sign));
        }

        [TestCase(1L, new[] { 1L })]
        [TestCase(2L, new[] { 2L })]
        [TestCase(6L, new[] { 2L, 3L })]
        [TestCase(9L, new[] { 3L, 3L })]
        [TestCase(36L, new[] { 2L, 2L, 3L, 3L })]
        [TestCase(97L, new[] { 97L })]
        public void DividersTests(long v, long[] dividers)
        {
            Assert.That(Mathematics.Dividers(v), Is.EquivalentTo(dividers));
        }

        [TestCase(new[] { 1L }, 1L)]
        [TestCase(new[] { 2L }, 2L)]
        [TestCase(new[] { 2L, 3L }, 6L)]
        [TestCase(new[] { 2L, 4L }, 4L)]
        [TestCase(new[] { 44L, 28L, 18L }, 2772L)]
        public void LeastCommonMultiplyTest(long[] values, long lcm)
        {
            Assert.That(Mathematics.LeastCommonMultiple(values), Is.EqualTo(lcm));
        }
    }
}