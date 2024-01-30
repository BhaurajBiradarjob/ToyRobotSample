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
        static bool IsOutput = true;
        static void Main(string[] args)
        {
            try
            {

                do
                {
                    ProcessCommand(args);
                } 
                while (IsOutput);
                
            }
            catch(Exception ex) 
            {
                ExceptionHandling.Instance.ThrowException(ex);
            }
            Console.ReadLine();
        }

        private static void ProcessCommand(string[] args)
        {
            Console.WriteLine("Please provide input file Path with .txt format");
            string path = Console.ReadLine();
            //args = new string[] { "D:\\Input\\11.txt" };
            if (File.Exists(path) && (Path.GetExtension(path) == ".txt"))
            {
                string[] commands = File.ReadAllLines(path);
                RegisterDependencies(args);

                var validateInputs = host.Services.GetService<IValidateInputs>();
                //if space, small letter, blank space exists then Reformat the string
                string[] reformattedcommand = validateInputs.FormatInput(commands);
                if (reformattedcommand != null && reformattedcommand.Length == 0)
                {
                    Console.WriteLine("Please add correct input in the file");
                    Console.WriteLine("#####################################");
                    return;
                }

                // Validate the input
                bool IsValidInput = validateInputs.ValidateInput(reformattedcommand);
                if (IsValidInput)
                {
                    var command = host.Services.GetService<ICommand>();
                    Console.WriteLine(command.Start(reformattedcommand));
                    IsOutput = false;
                }
                else
                {
                    Console.WriteLine("Please add correct input in the file and then Please try again");
                }
            }
            else
            {
                Console.WriteLine("Input file is not a .txt file or Please add correct input format in .txt file and then Please try again");
            }
        }

        static void RegisterDependencies(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddSingleton<IItem, Table>();
            builder.Services.AddSingleton<IValidateInputs, ValidateInputs>();
            builder.Services.AddSingleton<IMovement, MovementSimulator>();
            builder.Services.AddSingleton<IRobotMoves, RobotMovements>();
            builder.Services.AddSingleton<ICommand, Command>();
            host = builder.Build();
        }
    }
}
