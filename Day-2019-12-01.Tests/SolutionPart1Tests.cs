using NUnit.Framework;

namespace Day_2019_12_01.Tests
{
    public class SolutionPart1Tests
    {
        [TestCase(12, 2)]
        [TestCase(14, 2)]
        [TestCase(1969, 654)]
        [TestCase(100756, 33583)]
        public void Test(int mass, int fuel)
        {
            Assert.That(new SolutionPart1().CalculateRequiredFuel(mass), Is.EqualTo(fuel));
        }
    }
}