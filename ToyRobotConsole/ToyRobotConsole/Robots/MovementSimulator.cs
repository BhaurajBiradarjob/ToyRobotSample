using ToyRobotConsole.Interfaces;

namespace ToyRobotConsole.Robots
{
    public class MovementSimulator : IMovement
    {
        public IRobotMoves Robot { get ; set ; }
        private IItem Surface { get ; set ; }

        public MovementSimulator(IItem table, IRobotMoves robotMoves)
        {
            Surface = table;
            Robot = robotMoves;
        }

        public void Place(int east, int north, RobotMovementDirection direction)
        {
            if (Surface.IsValidLocation(east, north))
            {
                Robot.Direction = direction;
                Robot.East = east;
                Robot.North = north;
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
