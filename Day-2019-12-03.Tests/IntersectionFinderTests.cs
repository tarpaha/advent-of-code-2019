using NUnit.Framework;

namespace Day_2019_12_03.Tests
{
    public class IntersectionFinderTests
    {
        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [TestCase("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [TestCase("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void Test(string steps0, string steps1, int distance)
        {
            var wire0 = StepsParser.Parse(steps0);
            var wire1 = StepsParser.Parse(steps1);
            Assert.That(IntersectionFinder.FindDistanceOfClosestToOrigin(wire0, wire1), Is.EqualTo(distance));
        }
    }
}