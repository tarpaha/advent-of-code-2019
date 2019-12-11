using System.Linq;
using NUnit.Framework;
using Utils;
using Utils.Computer;

namespace Day_2019_12_11.Tests
{
    public class RobotTests
    {
        [Test]
        public void Test()
        {
            // program will output 1, 0
            // robot must paint 1 and move left
            var program = "4,5,4,6,99,1,0"
                .Split(',')
                .Select(long.Parse)
                .ToArray();
            var computer = new IntCodeComputer();
            computer.LoadProgram(program);
            
            var robot = new Robot(computer);
            var floor = new Floor();
            robot.Run(floor);
            
            Assert.That(floor.GetColor(new Vector2(0, 0)), Is.EqualTo(1));
            Assert.That(robot.GetPosition(), Is.EqualTo(new Vector2(-1, 0)));
            Assert.That(robot.GetDirection(), Is.EqualTo(Robot.Direction.Left));
        }
    }
}