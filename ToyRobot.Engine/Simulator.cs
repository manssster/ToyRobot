using System;
using ToyRobot.Engine.Common;
using ToyRobot.Engine.Enumeration;
using ToyRobot.Engine.Model;
using ToyRobot.Engine.Parser;

namespace ToyRobot.Engine
{
    public class RobotSimulator
    {
        public Robot Robot { get; set; }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public RobotSimulator()
        {
            Robot = new Robot();
            log.Info("Initializing RobotSimulator.");
        }

        public void ProcessInput(string commandString)
        {
            log.Info("Command: " + commandString);
            string[] args = commandString.Split(new[] { Constants.SPACECHAR }, 2);

            try
            {
                Command cmd = InputParser.GetCommand(args[0]);

                switch (cmd)
                {
                    case Command.PLACE:
                        if (args.Length > 1)
                        {
                            (int x, int y, Direction dir) = InputParser.ProcessPlaceCommand(args[1]);
                            Robot.Place(x, y, dir);
                        }
                        else
                        {
                            log.Error("PLACE command issued without location and direction arguments. please provide the following arguments: PLACE X,Y,F");
                        }
                        break;
                    case Command.LEFT:
                        Robot.Left();
                        break;
                    case Command.MOVE:
                        Robot.Move();
                        break;
                    case Command.RIGHT:
                        Robot.Right();
                        break;
                    default:
                        //anything apart from the handled commands need to be ignored.
                        log.Error(string.Format("Command {0} is invalid and will be ignored.", commandString));
                        break;
                }
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
            {
                //parsing errors will cause these exceptions so handle them as invalid commands
                log.Error(string.Format("Command {0} is invalid and will be ignored.", commandString));
            }
             
        }

        public string ReportOutput()
        {
            log.Info("Command: " + Command.REPORT.ToString());
            return Robot.Report();
        }
    }
}
