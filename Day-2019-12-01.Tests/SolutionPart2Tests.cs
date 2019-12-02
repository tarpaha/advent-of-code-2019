using NUnit.Framework;

namespace Day_2019_12_01.Tests
{
    public class SolutionPart2Tests
    {
        [TestCase(14, 2)]
        [TestCase(1969, 966)]
        [TestCase(100756, 50346)]
        public void Test(int mass, int fuel)
        {
            Assert.That(new SolutionPart2().CalculateRequiredFuel(mass), Is.EqualTo(fuel));
        }
    }
}