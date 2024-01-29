using ToyRobotConsole.Interfaces;

namespace ToyRobotConsole.Implementation
{
    /// <summary>
    /// Surface
    /// </summary>
    public class Table : IItem
    {
        public int Width { get ; set ; }
        public int Length { get ; set ; }

        /// <summary>
        /// Checking placed robot in valid surface
        /// </summary>
        /// <param name="East"></param>
        /// <param name="North"></param>
        /// <returns></returns>
        public bool IsValidLocation(int East, int North)
        {
            return East >= 0 && East < Width && North >= 0 && North < Length;
        }
    }
}
