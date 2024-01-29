namespace ToyRobotConsole.Interfaces
{
    public interface IItem
    {
        int Width { get; set; }
        int Length { get; set; }
        bool IsValidLocation(int East, int North);
    }
}
