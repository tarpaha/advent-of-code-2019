using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_16.Tests
{
    public class FFTTests
    {
        [TestCase("12345678", 1, 48226158)]
        [TestCase("12345678", 2, 34040438)]
        [TestCase("12345678", 3, 03415518)]
        [TestCase("80871224585914546619083218645595", 100, 24176176)]
        [TestCase("19617804207202209144916044189917", 100, 73745418)]
        [TestCase("69317163492948606335995924319873", 100, 52432133)]
        public void Test(string inputStr, int phases, int outputPrefix)
        {
            var input = inputStr.Select(ch => ch - '0').ToArray();
            var output = FFT.Process(input, phases);
            Assert.That(int.Parse(string.Join("", output.Take(8))), Is.EqualTo(outputPrefix));
        }
    }
}