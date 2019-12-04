using NUnit.Framework;

namespace Day_2019_12_04.Tests
{
    public class RangeTests
    {
        [TestCase(0, 0, new [] { 0 })]
        [TestCase(1, 2, new [] { 1, 2 })]
        [TestCase(10, 12, new [] { 10, 11, 12 })]
        public void GetRangeTest(int min, int max, int[] values)
        {
            Assert.That(Range.Get(min, max), Is.EquivalentTo(values));
        }
    }
}