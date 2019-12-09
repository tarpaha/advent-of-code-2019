using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_07.Tests
{
    public class Circuit1Tests
    {
        [TestCase("3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0", 43210)]
        [TestCase("3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0", 54321)]
        [TestCase("3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0", 65210)]
        public void Test(string programStr, int highestSignal)
        {
            Assert.That(Circuit1.GetHighestSignal(Parse(programStr)), Is.EqualTo(highestSignal));
        }
        
        private static long[] Parse(string str)
        {
            return string.IsNullOrEmpty(str)
                ? new long[0]
                : str.Split(',').Select(long.Parse).ToArray();
        }
    }
}