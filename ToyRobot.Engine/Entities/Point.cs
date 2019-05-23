using System;

namespace ToyRobot.Engine.Entities
{
    public class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            if (other == null)
                return false;

            if (X != other.X || Y != other.Y)
                return false;

            return true;
        }
    }
}
