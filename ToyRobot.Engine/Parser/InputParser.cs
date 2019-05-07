using System;
using ToyRobot.Engine.Common;
using ToyRobot.Engine.Enumeration;

namespace ToyRobot.Engine.Parser
{
    public static class InputParser
    {
        public static Command GetCommand(String commandString)
        {
            return (Command)Enum.Parse(typeof(Command), commandString, true);
        }

        public static (int, int, Direction) ProcessPlaceCommand(string placeArgs)
        {
            string[] args = placeArgs.Replace(Constants.SPACESTR, string.Empty).Split(Constants.COMMA);

            if (args.Length != 3) 
            {
                throw new ArgumentException(Constants.INVALID_PLACECOMMAND_ARGS_MESSAGE);
            }
            int x = int.Parse(args[0]);
            int y = int.Parse(args[1]);

            Direction dir = (Direction)Enum.Parse(typeof(Direction), args[2], true);
            return (x, y, dir);
        }
    }
}
