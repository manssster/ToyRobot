using ToyRobot.Engine.Common;

namespace ToyRobot.Engine.Model
{
    public class Location
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public int X { get; set; }
        public int Y { get; set; }

        public bool Placed { get; set; }

        public Location(int x, int y)
        {
            if ((x < Constants.TABLE_MAX_HEIGHT) && (x >= 0)  
                && (y < Constants.TABLE_MAX_WIDTH) && (y >= 0))
            {
                this.X = x;
                this.Y = y;
                this.Placed = true;
            }
            else
            {
                log.Error(string.Format("Unable to place robot. this location is out of bounds. the table size is {0} x {1}.", Constants.TABLE_MAX_WIDTH, Constants.TABLE_MAX_HEIGHT));
            }
        }

        public bool MoveTowardsNorth()
        {
            bool canMove = (Y < (Constants.TABLE_MAX_HEIGHT - 1));
            if (canMove)
                Y++;
            else
                log.Error("Robot cannot move any further north.");
            return canMove;
        }

        public bool MoveTowardsEast()
        {
            bool canMove = (X < (Constants.TABLE_MAX_WIDTH - 1));
            if (canMove)
                X++;
            else
                log.Error("Robot cannot move any further east.");
            return canMove;
        }

        public bool MoveTowardsSouth()
        {
            bool canMove = (Y > 0);
            if (canMove)
                Y--;
            else
                log.Error("Robot cannot move any further south.");
            return canMove;
        }

        public bool MoveTowardsWest()
        {
            bool canMove = (X > 0);
            if (canMove)
                X--;
            else
                log.Error("Robot cannot move any further west.");
            return canMove;
        }
    }
}
