using ToyRobotConsole.Robots;

namespace ToyRobotConsole.Interfaces
{
    public interface IRobotMoves
    {
        int East { get; set; }
        int North { get; set; } 
        RobotMovementDirection Direction { get; set; }
        void Move();
        void TurnLeft();
        void TurnRight();
        string GetDirection();
    }
}
