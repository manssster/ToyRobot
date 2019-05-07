using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToyRobot.Engine.Common;
using ToyRobot.Engine.Enumeration;

namespace ToyRobot.Engine.Parser.Tests
{
    [TestClass()]
    public class InputParserTests
    {
        [TestMethod()]
        public void ParseCommandTestInvalidCommand()
        {
            try
            {
                string expectedCmdString = "TESTING";
                Command result = InputParser.GetCommand("TESTING 123 435");
                Assert.IsTrue(expectedCmdString == result.ToString());
            }
            catch (ArgumentException ex)
            {
                string expected = "Requested value 'TESTING 123 435' was not found.";
                Assert.AreEqual(ex.Message, expected);
            }
        }

        [TestMethod()]
        public void ParseCommandTestValidCommand()
        {
            try
            {
                Command expected = Command.LEFT;
                Command actual = InputParser.GetCommand(Command.LEFT.ToString());
                Assert.IsTrue(expected == actual);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ProcessPlaceCommandTestValid()
        {
            try
            {
                (int x, int y, Direction dir) = InputParser.ProcessPlaceCommand("0,0,NORTH");
                Assert.IsTrue(true);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ProcessPlaceCommandTestDirectionInvalid()
        {
            try
            {
                (int x, int y, Direction dir) = InputParser.ProcessPlaceCommand("0,0,F");
                Assert.IsTrue(true);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
            {
                string expected = "Requested value 'F' was not found.";
                Assert.AreEqual(ex.Message, expected);
            }
        }

        [TestMethod()]
        public void ProcessPlaceCommandTestLocationInvalid()
        {
            try
            {
                (int x, int y, Direction dir) = InputParser.ProcessPlaceCommand("XX,XX,NORTH");
                Assert.IsTrue(true);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
            {
                string expected = "Input string was not in a correct format.";
                Assert.AreEqual(ex.Message, expected);
            }
        }

        [TestMethod()]
        public void ProcessPlaceCommandTestArgumentsCountGreater()
        {
            try
            {
                (int x, int y, Direction dir) = InputParser.ProcessPlaceCommand("0,0,NORTH,EXTRADATA");
                Assert.IsTrue(true);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
            {
                Assert.AreEqual(ex.Message, Constants.INVALID_PLACECOMMAND_ARGS_MESSAGE);
            }
        }
    }
}