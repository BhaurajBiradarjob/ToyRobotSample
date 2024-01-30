using System;

namespace ToyRobotConsole.Helper
{
    public class ExceptionHandling : Exception
    {
        private static ExceptionHandling instance = null;
        public static ExceptionHandling Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExceptionHandling();
                }
                return instance;
            }
        }
        private ExceptionHandling()
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
