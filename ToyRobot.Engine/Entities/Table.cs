using System.Collections.Generic;

namespace ToyRobot.Engine.Entities
{
    public static class Table
    {
        public static bool IsPointNotObstructed(int x, int y)
        {
            bool isNotObstructed = true;

            Point p = new Point(x, y);
            foreach (Point obstruction in GetObstructedPoints())
            {
                if (obstruction.Equals(p)) {
                    isNotObstructed = false;
                }
            }

            return isNotObstructed;
        }

        private static List<Point> GetObstructedPoints()
        {
            List<Point> AllObstructions = new List<Point>
            {
                new Point(1, 1),
                new Point(2, 1),
                new Point(3, 1),
                new Point(1, 3)
            };

            return AllObstructions;

        }
    }
}
