

using System.Text.RegularExpressions;
using System;
using ToyRobotConsole.Interfaces;
using ToyRobotConsole.Robots;
using ToyRobotConsole.Helper;

namespace ToyRobotConsole.Implementation
{
    /// <summary>
    /// Communication with Robot
    /// </summary>
    public class Command : ICommand
    {
        private MovementSimulator Simulation;
        private IItem Table;
        public bool Placed;
        public string Message = string.Empty;
        public string ErrorInputs = Constants.ErrorMessage;

        public Command(IMovement movement, IItem item)
        {
            Simulation = (MovementSimulator)movement;
            Table = item;
            Table.Width = Constants.ItemWidth;
            Table.Length = Constants.ItemLength;
        }

        /// <summary>
        /// Initializes communication
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        public string Start(string[] commands)
        {
            try
            {
                foreach (string command in commands)
                {
                    if (Placed)
                    {
                        ProcessCommand(command);
                    }
                    else if (Regex.IsMatch(command, "[PLACE]"))
                    {
                        Placed = true;
                        ProcessCommand(command);
                    }
                    if (Message == ErrorInputs)
                    {
                        break;
                    }
                    if (Message.Length > 1)
                    {
                        Console.WriteLine(Message);
                        Message = "";
                    }
                }
                return Message;
            }
            catch (Exception ex)
            {
                ExceptionHandling.Instance.ThrowException(ex);
            }
            return Message;
        }

        /// <summary>
        /// Processing movements
        /// </summary>
        /// <param name="command"></param>
        public void ProcessCommand(string command)
        {
            if (Regex.IsMatch(command, "^PLACE"))
            {
                string[] coordinates = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (coordinates.Length == 4)
                {
                    int east;
                    int north;
                    bool eastTest = Int32.TryParse(coordinates[1], out east);
                    bool northTest = Int32.TryParse(coordinates[2], out north);
                    if (eastTest && northTest)
                    {
                        RobotMovementDirection myStatus;
                        Enum.TryParse(coordinates[3],true, out myStatus);
                        Simulation.Place(east, north, myStatus);
                    }
                }
                if (Simulation.Robot == null)
                {
                    Message = ErrorInputs;
                }
            }
            else if (Regex.IsMatch(command, "^MOVE") || Regex.IsMatch(command, "^RIGHT") || Regex.IsMatch(command, "^LEFT"))
            {
                MoveDirection moveStatus;
                Enum.TryParse(command, true, out moveStatus);

                Simulation.RobotMoves(moveStatus);
            }
            else if (Regex.IsMatch(command, "^REPORT"))
            {
                Message = Simulation.Report();
            }
            else
            {
                Message = ErrorInputs;
            }
        }
    }
}
