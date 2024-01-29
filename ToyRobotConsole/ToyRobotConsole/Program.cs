using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using ToyRobotConsole.Helper;
using ToyRobotConsole.Implementation;
using ToyRobotConsole.Interfaces;
using ToyRobotConsole.Robots;

namespace ToyRobotConsole
{
    public class Program
    {
        static IHost host;
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please specify a .txt filepath.");
                return;
            }
            RegisterDependencies(args);
            //args = new string[]{ "D:\\11.txt"};
            if (File.Exists(args[0]) && (Path.GetExtension(args[0]) == ".txt"))
            {
                string[] commands = File.ReadAllLines(args[0]);
                var command = host.Services.GetService<ICommand>();
                Console.WriteLine(command.Start(commands));
            }
            else
            {
                Console.WriteLine("Input file is not a .txt file or Please add correct input format in .txt file and then Please try again");
            }
            Console.ReadLine();
        }

        static void RegisterDependencies(string[] args)
        {
            try
            {
                HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
                builder.Services.AddSingleton<IItem, Table>();
                builder.Services.AddSingleton<IMovement, MovementSimulator>();
                builder.Services.AddSingleton<IRobotMoves, RobotMovements>();
                builder.Services.AddSingleton<ICommand, Command>();
                host = builder.Build();
            }
            catch (Exception ex)
            {
                ExceptionHandling.Instance.ThrowException(ex);
            }
        }
    }
}
