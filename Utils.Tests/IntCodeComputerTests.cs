using System;
using System.Linq;
using NUnit.Framework;
using Utils.Computer;

namespace Utils.Tests
{
    public class IntCodeComputerTests
    {
        private readonly Random _random = new Random();
        private readonly IntCodeComputer _computer = new IntCodeComputer();
        
        [Test]
        public void TestThatProgramAreInMemoryAfterLoad()
        {
            var data = MakeRandomData();
            _computer.LoadProgram(data);
            Assert.That(_computer.GetMemory(), Is.EquivalentTo(data));
        }

        [Test]
        public void TestThatRestoreRestoresMemory()
        {
            var data = MakeRandomData();
            _computer.LoadProgram(data);
            _computer.SetMemory(0, _computer.GetMemory(0) + 1);
            Assert.That(_computer.GetMemory(), Is.Not.EquivalentTo(data));
            _computer.Reset();
            Assert.That(_computer.GetMemory(), Is.EquivalentTo(data));
        }

        [Test]
        public void TestThatSetGetMemoryWorks()
        {
            var data = MakeRandomData();
            _computer.LoadProgram(data);
            for (var offset = 0; offset < data.Length; offset++)
            {
                var number = _random.Next();
                _computer.SetMemory(offset, number);
                Assert.That(_computer.GetMemory(offset), Is.EqualTo(number));
            }
        }
        
        private long[] MakeRandomData()
        {
            const int length = 10;
            return Enumerable.Repeat(0, length).Select(_ => (long)_random.Next()).ToArray();
        }

        [TestCase("", "1,0,0,0,99", "2,0,0,0,99", "")]
        [TestCase("", "2,3,0,3,99", "2,3,0,6,99", "")]
        [TestCase("", "2,4,4,5,99,0", "2,4,4,5,99,9801", "")]
        [TestCase("", "1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99", "")]
        [TestCase("5", "3,0,99", "5,0,99", "")]
        [TestCase("12,34", "3,5,3,6,99,0,0", "3,5,3,6,99,12,34", "")]
        [TestCase("", "4,0,99", "4,0,99", "4")]
        [TestCase("", "4,9,4,8,4,7,99,1,2,3", "4,9,4,8,4,7,99,1,2,3", "3,2,1")]
        [TestCase("", "1002,4,3,4,33,99", "1002,4,3,4,99,99", "")]
        [TestCase("", "104,42,99", "104,42,99", "42")]
        [TestCase("", "1101,100,-1,4,0", "1101,100,-1,4,99", "")]
        [TestCase("8", "3,9,8,9,10,9,4,9,99,-1,8", "-", "1")]
        [TestCase("9", "3,9,8,9,10,9,4,9,99,-1,8", "-", "0")]
        [TestCase("7", "3,9,7,9,10,9,4,9,99,-1,8", "-", "1")]
        [TestCase("8", "3,9,7,9,10,9,4,9,99,-1,8", "-", "0")]
        [TestCase("8", "3,3,1108,-1,8,3,4,3,99", "-", "1")]
        [TestCase("9", "3,3,1108,-1,8,3,4,3,99", "-", "0")]
        [TestCase("7", "3,3,1107,-1,8,3,4,3,99", "-", "1")]
        [TestCase("8", "3,3,1107,-1,8,3,4,3,99", "-", "0")]
        [TestCase("0", "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", "-", "0")]
        [TestCase("1", "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", "-", "1")]
        [TestCase("0", "3,3,1105,-1,9,1101,0,0,12,4,12,99,1", "-", "0")]
        [TestCase("1", "3,3,1105,-1,9,1101,0,0,12,4,12,99,1", "-", "1")]
        [TestCase("1", "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", "-", "999")]
        [TestCase("8", "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", "-", "1000")]
        [TestCase("10", "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", "-", "1001")]
        public void TestExecution(string inputStr, string programStr, string memoryStr, string outputStr)
        {
            var computer = new IntCodeComputer();
            computer.LoadProgram(Parse(programStr));
            foreach (var input in Parse(inputStr))
                computer.AddInput(input);
            var output = new BufferOutput();
            computer.SetOutput(output);
            computer.Run();
            if(memoryStr != "-")
                Assert.That(computer.GetMemory(), Is.EquivalentTo(Parse(memoryStr)));
            Assert.That(output.Data, Is.EquivalentTo(Parse(outputStr)));
        }

        private static long[] Parse(string str)
        {
            return string.IsNullOrEmpty(str)
                ? new long[0]
                : str.Split(',').Select(long.Parse).ToArray();
        }
    }
}