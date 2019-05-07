using ToyRobot.Engine.Enumeration;
using ToyRobot.Engine.Model;

namespace ToyRobot.Engine.Entities
{
    public class Orientation
    {
        private readonly Location location;
        private Direction direction;

        public Orientation(Location location, Direction direction)
        {
            this.location = location;
            this.direction = direction;
        }

        public Location Location => location;
        public Direction Direction => direction;

        internal bool MoveInCurrentDirection()
        {
            switch (direction)
            {
                case Direction.NORTH:
                    return location.MoveTowardsNorth();
                case Direction.SOUTH:
                    return location.MoveTowardsSouth();
                case Direction.EAST:
                    return location.MoveTowardsEast();
                case Direction.WEST:
                    return location.MoveTowardsWest();
                default: return false;
            }
        }

        internal void TurnLeftFromCurrentPosition()
        {
            if (this.direction == Direction.NORTH)
            {
                this.direction = Direction.WEST;
            }
            else
            {
                this.direction--;
            }
        }

        internal void TurnRightFromCurrentPosition()
        {
            if (this.direction == Direction.WEST)
            {
                this.direction = Direction.NORTH;
            }
            else
            {
                this.direction++;
            }
        }
    }
}
