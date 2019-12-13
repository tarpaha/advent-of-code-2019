using System.Linq;
using NUnit.Framework;

namespace Day_2019_12_13.Tests
{
    public class ArcadeCabinetTests
    {
        [TestCase("4,7,4,8,4,9,99,1,2,1", 0)]
        [TestCase("4,7,4,8,4,9,99,1,2,2", 1)]
        public void RunProgramTest(string programStr, int blockTilesCount)
        {
            var screen = new Screen();
            var arcadeCabinet = new ArcadeCabinet(screen, Parse(programStr));
            arcadeCabinet.Run();
            Assert.That(screen.BlockTilesCount, Is.EqualTo(blockTilesCount));
        }
        
        private static long[] Parse(string str)
        {
            return string.IsNullOrEmpty(str)
                ? new long[0]
                : str.Split(',').Select(long.Parse).ToArray();
        }
    }
}