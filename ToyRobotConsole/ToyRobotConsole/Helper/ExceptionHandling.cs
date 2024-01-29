using System;

namespace ToyRobotConsole.Helper
{
    public class ExceptionHandling : Exception
    {
        public static ExceptionHandling Instance = new ExceptionHandling();
        public ExceptionHandling()
        {
        }

        public ExceptionHandling(string message)
            : base(message)
        {
        }

        public ExceptionHandling(string message, Exception inner)
            : base(message, inner)
        {
        }
        public void ThrowException(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.WriteLine(Constants.ErrorMessage);
        }
    }
}
