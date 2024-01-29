using ToyRobotConsole.Implementation;

namespace ToyRobotConsole.Robots
{
    public class MovementSimulator
    {
        public RobotMovements Robot;
        public Table Surface;

        public MovementSimulator(Table table)
        {
            Surface = table;
        }

        public void Place(int east, int north, RobotMovementDirection direction)
        {
            if (Surface.IsValidLocation(east, north))
            {
                Robot = new RobotMovements
                {
                    Direction = direction,
                    East = east,
                    North = north
                };
            }
        }

        public void RobotMoves(MoveDirection movement)
        {
            switch (movement)
            {
                case MoveDirection.Move:
                    if (Surface.IsValidLocation(Robot.East + 1, Robot.North + 1)
                        && Surface.IsValidLocation(Robot.East , Robot.North))
                    {
                        Robot.Move();
                    }
                    break;
                case MoveDirection.Right:
                    Robot.TurnRight();
                    break;
                case MoveDirection.Left:
                    Robot.TurnLeft();
                    break;
            }
        }

        public string Report()
        {
            return Robot.GetDirection();
        }
    }
}
