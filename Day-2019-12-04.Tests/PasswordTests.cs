using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_04.Tests
{
    public class PasswordTests
    {
        [TestCase("111111", true)]
        [TestCase("223450", false)]
        [TestCase("123789", false)]
        public void TestType1(string digitsStr, bool correct)
        {
            Assert.That(Password.IsCorrectType1(Digits(digitsStr)), Is.EqualTo(correct));
        }
        
        [TestCase("112233", true)]
        [TestCase("123444", false)]
        [TestCase("111122", true)]
        [TestCase("123455", true)]
        [TestCase("113456", true)]
        [TestCase("122244", true)]
        [TestCase("222244", true)]
        [TestCase("222444", false)]
        [TestCase("222245", false)]
        [TestCase("123456", false)]
        [TestCase("224445", true)]
        public void TestType2(string digitsStr, bool correct)
        {
            Assert.That(Password.IsCorrectType2(Digits(digitsStr)), Is.EqualTo(correct));
        }

        private static int[] Digits(string digitsStr)
        {
            return digitsStr.Select(ch => ch - '0').ToArray();
        }
    }
}