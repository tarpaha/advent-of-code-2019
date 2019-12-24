using NUnit.Framework;

namespace Day_2019_12_16.Tests
{
    public class PatternTests
    {
        [TestCase(4, 1, "1,0,-1,0")]
        [TestCase(5, 1, "1,0,-1,0,1")]
        [TestCase(15, 2, "0,1,1,0,0,-1,-1,0,0,1,1,0,0,-1,-1")]
        public void GeneratorTest(int length, int position, string patternStr)
        {
            var pattern = Pattern.Generator(length, position);
            Assert.That(string.Join(",", pattern), Is.EqualTo(patternStr));
        }
    }
}