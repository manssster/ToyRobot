using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Engine.Common;
using ToyRobot.Engine.Enumeration;

namespace ToyRobot.Engine.Model.Tests
{
    [TestClass()]
    public class RobotTests
    {
        Robot robot;

        [TestInitialize]
        public void Initialize()
        {
            robot = new Robot();
        }

        [TestMethod()]
        public void ReportTestOnNotPlaced()
        {
            string expected = string.Empty;
            string actual = robot.Report();
            Assert.IsTrue(actual == expected);
        }

        [TestMethod()]
        public void ReportTestOnPlaced()
        {
            string expected = "0, 0, NORTH";
            string actual;
            robot.Place(0, 0, Direction.NORTH);
            actual = robot.Report();
            Assert.IsTrue(actual == expected);
        }

        [TestMethod()]
        public void PlaceTestValidLocation()
        {
            //In bounds of the table. Placement should be successful
            robot.Place(Constants.TABLE_MAX_WIDTH -2, Constants.TABLE_MAX_HEIGHT -1, Direction.SOUTH);
            Assert.IsTrue(robot.IsPlaced());
        }

        [TestMethod()]
        public void PlaceTestInvalidLocation()
        {
            //out of bounds of the table. Placement should be unsuccessful
            robot.Place(Constants.TABLE_MAX_WIDTH + 2, Constants.TABLE_MAX_HEIGHT + 1, Direction.NORTH);
            Assert.IsFalse(robot.IsPlaced());
        }

        [TestMethod()]
        public void MoveTestFacingNorthValid()
        {
            //when placed at 0,0,N move will be valid
            robot.Place(0, 0, Direction.NORTH);
            Assert.IsTrue(robot.Move());
        }

        [TestMethod()]
        public void MoveTestFacingEastValid()
        {
            //when placed at 0,0,E move will be valid
            robot.Place(0,0, Direction.EAST);
            Assert.IsTrue(robot.Move());
        }

        [TestMethod()]
        public void MoveTestFacingSouthValid()
        {
            //when placed at MAX,MAX,S move will be valid
            robot.Place(Constants.TABLE_MAX_HEIGHT - 1, Constants.TABLE_MAX_WIDTH - 1, Direction.SOUTH);
            Assert.IsTrue(robot.Move());
        }

        [TestMethod()]
        public void MoveTestFacingWestValid()
        {
            //when placed at MAX,MAX,W move will be valid
            robot.Place(Constants.TABLE_MAX_HEIGHT - 1, Constants.TABLE_MAX_WIDTH - 1, Direction.WEST);
            Assert.IsTrue(robot.Move());
        }

        [TestMethod()]
        public void MoveTestFacingNorthInvalid()
        {
            //when placed at MAX,MAX,N move will be invalid
            robot.Place(Constants.TABLE_MAX_HEIGHT - 1, Constants.TABLE_MAX_WIDTH - 1, Direction.NORTH);
            Assert.IsFalse(robot.Move());
        }

        [TestMethod()]
        public void MoveTestFacingEastInvalid()
        {
            //when placed at MAX,MAX,E move will be invalid
            robot.Place(Constants.TABLE_MAX_HEIGHT-1, Constants.TABLE_MAX_WIDTH-1, Direction.EAST);
            Assert.IsFalse(robot.Move());
        }

        [TestMethod()]
        public void MoveTestFacingSouthInvalid()
        {
            //when placed at 0,0,S move will be invalid
            robot.Place(0,0, Direction.SOUTH);
            Assert.IsFalse(robot.Move());
        }

        [TestMethod()]
        public void MoveTestFacingWestInvalid()
        {
            //when placed at 0,0,W move will be invalid
            robot.Place(0,0, Direction.WEST);
            Assert.IsFalse(robot.Move());
        }

        [TestMethod()]
        public void LeftTest()
        {
            //when placed at 0,0,NORTH left will be 0,0,WEST
            string expected = "0, 0, WEST";
            robot.Place(0, 0, Direction.NORTH);
            robot.Left();
            Assert.AreEqual(expected, robot.Report());
        }

        [TestMethod()]
        public void RightTest()
        {
            //when placed at 0,0,WEST right will be 0,0,NORTH
            string expected = "0, 0, NORTH";
            robot.Place(0, 0, Direction.WEST);
            robot.Right();
            Assert.AreEqual(expected, robot.Report());
        }
    }
}