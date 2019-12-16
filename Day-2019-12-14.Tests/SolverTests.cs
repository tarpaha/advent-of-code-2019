using NUnit.Framework;

namespace Day_2019_12_14.Tests
{
    public class SolverTests
    {
        [TestCase("10 ORE => 10 A|1 ORE => 1 B|7 A, 1 B => 1 C|7 A, 1 C => 1 D|7 A, 1 D => 1 E|7 A, 1 E => 1 FUEL", 31)]
        [TestCase("9 ORE => 2 A|8 ORE => 3 B|7 ORE => 5 C|3 A, 4 B => 1 AB|5 B, 7 C => 1 BC|4 C, 1 A => 1 CA|2 AB, 3 BC, 4 CA => 1 FUEL", 165)]
        public void Test(string data, int ore)
        {
            var reactions = Parser.Parse(data);
            Assert.That(Solver.CalculateOreAmountForOneFuel(reactions), Is.EqualTo(ore));
        }
    }
}