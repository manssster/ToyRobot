using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Engine.Common;

namespace ToyRobot.Engine.Model.Tests
{
    [TestClass()]
    public class LocationTests
    {
        [TestMethod()]
        public void LocationTestValid()
        {
            Location location = new Location(0, 0);
            Assert.IsTrue(location.Placed);
        }

        [TestMethod()]
        public void LocationTestInvalid()
        {
            Location location = new Location(Constants.TABLE_MAX_HEIGHT, Constants.TABLE_MAX_WIDTH);
            Assert.IsFalse(location.Placed);
        }

        [TestMethod()]
        public void LocationTestNegative()
        {
            Location location = new Location(-1, -1);
            Assert.IsFalse(location.Placed);
        }
    }
}