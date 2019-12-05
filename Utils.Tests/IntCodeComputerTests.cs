using System;
using System.Linq;
using NUnit.Framework;

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
            _computer.RestoreMemory();
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
        
        private int[] MakeRandomData()
        {
            const int length = 10;
            return Enumerable.Repeat(0, length).Select(_ => _random.Next()).ToArray();
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
        public void TestExecution(string inputStr, string programStr, string memoryStr, string outputStr)
        {
            var computer = new IntCodeComputer();
            computer.LoadProgram(Parse(programStr));
            computer.SetInput(Parse(inputStr));
            computer.Execute();
            Assert.That(computer.GetMemory(), Is.EquivalentTo(Parse(memoryStr)));
            Assert.That(computer.GetOutput(), Is.EquivalentTo(Parse(outputStr)));
        }

        private static int[] Parse(string str)
        {
            return string.IsNullOrEmpty(str)
                ? new int[0]
                : str.Split(',').Select(int.Parse).ToArray();
        }
    }
}