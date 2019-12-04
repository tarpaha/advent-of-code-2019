using NUnit.Framework;

namespace Day_2019_12_04.Tests
{
    public class ConverterTests
    {
        [TestCase(111111, new [] { 1, 1, 1, 1, 1, 1 })]
        [TestCase(223450, new [] { 2, 2, 3, 4, 5, 0 })]
        [TestCase(123789, new [] { 1, 2, 3, 7, 8, 9 })]
        public void Test(int value, int[] digits)
        {
            Assert.That(Converter.ToSixDigits(value), Is.EquivalentTo(digits));
        }
    }
}