using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobot.Engine.Tests
{
    [TestClass()]
    public class RobotSimulatorTests
    {
        RobotSimulator simulator;

        [TestInitialize]
        public void Initialize()
        {
            simulator = new RobotSimulator();
        }

        [TestMethod()]
        public void ProcessPlaceCommandWithoutArgs()
        {
            try
            {
                simulator.ProcessInput("PLACE");
                Assert.IsFalse(simulator.Robot.IsPlaced());
            }
            catch (System.Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ProcessPlaceCommand()
        {
            try
            {
                simulator.ProcessInput("PLACE 0,0,NORTH");
                Assert.IsTrue(simulator.Robot.IsPlaced());
            }
            catch (System.Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ProcessPlaceCommandOnObstruction()
        {
            try
            {
                simulator.ProcessInput("PLACE 1,1,NORTH");
                Assert.IsFalse(simulator.Robot.IsPlaced());
            }
            catch (System.Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ProcessPlaceCommandWithSpaces()
        {
            try
            {
                simulator.ProcessInput("PLACE 0,  0,   NORTH");
                Assert.IsTrue(simulator.Robot.IsPlaced());
            }
            catch (System.Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ProcessMoveCommand()
        {
            try
            {
                simulator.ProcessInput("MOVE");
                Assert.IsTrue(true);
            }
            catch (System.Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ProcessLeftCommand()
        {
            try
            {
                simulator.ProcessInput("LEFT");
                Assert.IsTrue(true);
            }
            catch (System.Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ProcessRightCommand()
        {
            try
            {
                simulator.ProcessInput("RIGHT");
                Assert.IsTrue(true);
            }
            catch (System.Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ReportOutputTest()
        {
            string expected = "0, 0, NORTH";
            simulator.ProcessInput("PLACE 0, 0, NORTH");
            Assert.AreEqual(simulator.ReportOutput(), expected);
        }
    }
}