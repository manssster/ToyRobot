using ToyRobot.Engine.Common;
using ToyRobot.Engine.Entities;

namespace ToyRobot.Engine.Model
{
    public class Location
    {
        public Point Point { get; set; }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool Placed { get; set; }

        public Location(int x, int y)
        {
            if ((x < Constants.TABLE_MAX_HEIGHT) && (x >= 0) &&
                (y < Constants.TABLE_MAX_WIDTH) && (y >= 0) &&
                Table.IsPointNotObstructed(x,y))
            {
                this.Point = new Point(x, y);
                this.Placed = true;
            }
            else
            {
                log.Error(string.Format("Unable to place robot. this location is out of bounds. the table size is {0} x {1}.", Constants.TABLE_MAX_WIDTH, Constants.TABLE_MAX_HEIGHT));
            }
        }

        public bool MoveTowardsNorth()
        {
            bool canMove = (Point.Y < (Constants.TABLE_MAX_HEIGHT - 1));
            if (!canMove)
            {
                log.Error("Robot cannot move any further north.");
                return canMove;
            }

            canMove = Table.IsPointNotObstructed(Point.X, Point.Y +1);

            if (!canMove)
            {
                log.Error("Robot cannot move as there is an obstruction.");
                return canMove;
            }

            Point.Y++;
            return true;
        }

        public bool MoveTowardsEast()
        {
            bool canMove = (Point.X < (Constants.TABLE_MAX_WIDTH - 1));
            if (!canMove)
            {
                log.Error("Robot cannot move any further east.");
                return canMove;
            }

            canMove = Table.IsPointNotObstructed(Point.X + 1, Point.Y);
            if (!canMove)
            {
                log.Error("Robot cannot move as there is an obstruction.");
                return canMove;
            }

            Point.X++;
            return true;
        }

        public bool MoveTowardsSouth()
        {
            bool canMove = (Point.Y > 0);
            if (!canMove)
            {
                log.Error("Robot cannot move any further south.");
                return canMove;
            }

            canMove = Table.IsPointNotObstructed(Point.X, Point.Y - 1);
            if (!canMove)
            {
                log.Error("Robot cannot move as there is an obstruction.");
                return canMove;
            }

            Point.Y--;
            return true;
        }

        public bool MoveTowardsWest()
        {
            bool canMove = (Point.X > 0);
            if (!canMove)
            {
                log.Error("Robot cannot move any further west.");
                return canMove;
            }

            canMove = Table.IsPointNotObstructed(Point.X, Point.Y - 1);
            if (!canMove)
            {
                log.Error("Robot cannot move as there is an obstruction.");
                return canMove;
            }

            Point.X--;
            return true;
        }
    }
}
