using System;
using System.IO;
using ToyRobot.Engine;
namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            RobotSimulator simulator = new RobotSimulator();

            Console.WriteLine("TOY ROBOT SIMULATION");
            Console.WriteLine("following commands are understood: ");
            Console.WriteLine("PLACE X, Y, F");
            Console.WriteLine("MOVE");
            Console.WriteLine("LEFT");
            Console.WriteLine("RIGHT");
            Console.WriteLine("REPORT");
            Console.WriteLine("\n");

            //if argument is provided then process the command from the argument file
            if ((args.Length > 0) && (!String.IsNullOrEmpty(args[0])) && (File.Exists(Directory.GetCurrentDirectory() + "\\" + args[0]))
                )
            {
                string[] lines = File.ReadAllLines(args[0]);
                foreach(string line in lines)
                {
                    ProcessLine(line, simulator);
                }
            }
            else
            {
                while (true)
                {
                    Console.Write("COMMAND>> ");
                    string line = Console.ReadLine();
                    ProcessLine(line, simulator);

                }
            }

            Console.ReadLine();
        }

        private static void ProcessLine(String line, RobotSimulator simulator)
        {
            if (line.ToLower().Equals("exit"))
            {
                Environment.Exit(0);
            }

            if (line.ToLower().Equals(ToyRobot.Engine.Enumeration.Command.REPORT.ToString().ToLower()))
            {
                Console.WriteLine(simulator.ReportOutput());
            }
            else
            {
                simulator.ProcessInput(line);
            }
        }
    }
}
