using ToyRobotConsole.Robots;

namespace ToyRobotConsole.Interfaces
{
    public interface IMovement
    {
        void Place(int east, int north, RobotMovementDirection direction);
        void RobotMoves(MoveDirection movement);
        string Report();
    }
}
