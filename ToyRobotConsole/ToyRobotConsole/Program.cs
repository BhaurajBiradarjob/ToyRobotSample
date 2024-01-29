using System;
using System.IO;
using ToyRobotConsole.Implementation;

namespace ToyRobotConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please specify a .txt filepath.");
                return;
            }
            //args = new string[]{ "D:\\11.txt"};
            if (File.Exists(args[0]) && (Path.GetExtension(args[0]) == ".txt"))
            {
                string[] commands = File.ReadAllLines(args[0]);
                Console.WriteLine(new Command().Start(commands));
            }
            else
            {
                Console.WriteLine("Input file is not a .txt file or Please add correct input format in .txt file and then Please try again");
            }
            Console.ReadLine();
        }
    }
}
