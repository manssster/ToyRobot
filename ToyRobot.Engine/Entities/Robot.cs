using System;
using ToyRobot.Engine.Entities;
using ToyRobot.Engine.Enumeration;

namespace ToyRobot.Engine.Model
{
    public class Robot
    {
        private Orientation orientation;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Robot()
        {
        }

        public string Report()
        {
            if (IsPlaced())
            {
                return String.Format("{0}, {1}, {2}", this.orientation.Location.Point.X, this.orientation.Location.Point.Y, this.orientation.Direction.ToString());
            }
            else
            {
                return String.Empty;
            }
        }

        public void Place(int x, int y, Direction direction)
        {
            InitOrientation(x, y, direction);
        }

        public bool Move()
        {
            return IsPlaced() ? orientation.MoveInCurrentDirection() : false;         
        }

        public void Left()
        {
            if (IsPlaced()) orientation.TurnLeftFromCurrentPosition();
        }

        public void Right()
        {
            if (IsPlaced()) orientation.TurnRightFromCurrentPosition();
        }

        public void InitOrientation(int x, int y, Direction direction)
        {
            Location location = new Location(x, y);
            this.orientation = new Orientation(location, direction);
        }

        public bool IsPlaced()
        {
            bool isPlaced;
            bool? result = this.orientation?.Location?.Placed;
            isPlaced = result ?? false;

            if (!isPlaced)
            {
                log.Info("Robot has not been placed yet.");
            }

            return isPlaced;
        }
    }
}
