using System;
using ToyRobotConsole.Interfaces;
using ToyRobotConsole.Robots;

namespace ToyRobotConsole
{
    public class RobotMovements : IRobotMoves
    {
        public int East { get; set; } = 0;
        public int North { get; set; } = 0;
        public RobotMovementDirection Direction { get; set; }
                
        public void Move()
        {
            switch (Direction)
            {
                case RobotMovementDirection.East:
                    East += 1;
                    break;
                case RobotMovementDirection.West:
                    East -= 1;
                    break;
                case RobotMovementDirection.North:
                    North += 1;
                    break;
                case RobotMovementDirection.South:
                    North -= 1;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case RobotMovementDirection.East:
                    Direction = RobotMovementDirection.North;
                    break;
                case RobotMovementDirection.West:
                    Direction = RobotMovementDirection.South;
                    break;
                case RobotMovementDirection.North:
                    Direction = RobotMovementDirection.West;
                    break;
                case RobotMovementDirection.South:
                    Direction = RobotMovementDirection.East;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case RobotMovementDirection.East:
                    Direction = RobotMovementDirection.South;
                    break;
                case RobotMovementDirection.West:
                    Direction = RobotMovementDirection.North;
                    break;
                case RobotMovementDirection.North:
                    Direction = RobotMovementDirection.East;
                    break;
                case RobotMovementDirection.South:
                    Direction = RobotMovementDirection.West;
                    break;
            }
        }

        public string GetDirection()
        {
            return East + "," + North + "," + Enum.GetName(Direction.GetType(), Direction).ToUpper();
        }
    }
}
