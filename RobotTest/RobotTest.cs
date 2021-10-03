using NUnit.Framework;
using Robot;
using System.Collections.Generic;
namespace RobotTest
{
    [TestFixture]
    public class RobotTest
    {
        private List<Robot.Robot> ExpectedRobotList = new List<Robot.Robot>();
        private TableDriver tableDriver = new TableDriver(5, 5);
        [SetUp]
        public void Setup()
        {
            ExpectedRobotList.Add(new Robot.Robot(new Position(0, 0, Direction.WEST)) { ACTIVE = true });
            ExpectedRobotList.Add(new Robot.Robot(new Position(3, 3, Direction.NORTH)) { ACTIVE = true });
            
            var inputFile = "input.txt";
            var commands = Helper.GetCommands(inputFile);
            RobotChallenge.Run(commands,tableDriver);
        }
        [Test]
        public void CheckNumberOfRobot()
        {
            Assert.AreEqual(tableDriver.RobotList.Count, ExpectedRobotList.Count);
        }
        [Test]
        public void CheckRobotValue()
        {
            for(int i = 0 ; i < ExpectedRobotList.Count; i++)
            {
                var expectedRobot = ExpectedRobotList[i];
                var actualRobot = tableDriver.RobotList[i];
                Assert.AreEqual(expectedRobot.Position.X, actualRobot.Position.X);
                Assert.AreEqual(expectedRobot.Position.Y, actualRobot.Position.Y);
                Assert.AreEqual(expectedRobot.Position.Direction, actualRobot.Position.Direction);
                Assert.AreEqual(expectedRobot.ACTIVE, actualRobot.ACTIVE);

            }
        }
    }
}