using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToyRobotConsole.Helper;
using ToyRobotConsole.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace ToyRobotConsole.Implementation
{
    public class ValidateInputs : IValidateInputs
    {
        public bool ValidateInput(string[] commands)
        {
            if (!Regex.IsMatch(commands[0], "[PLACE]"))
                return false;

            if (!Regex.IsMatch(commands[commands.Length-1], "^REPORT"))
                return false;

            foreach (string command in commands)
            {
                if (string.IsNullOrEmpty(command))
                    continue;

                if (!Validate(command))
                    return false;
            }
            return true;
        }

        private bool Validate(string command)
        {
            if(Regex.IsMatch(command.ToUpper(), "[PLACE]") || Regex.IsMatch(command.ToUpper(), "^MOVE") ||
                   Regex.IsMatch(command.ToUpper(), "^RIGHT") || Regex.IsMatch(command.ToUpper(), "^LEFT") ||
                   Regex.IsMatch(command.ToUpper(), "^REPORT"))
                         return true;
            return false;
        }

        public string[] FormatInput(string[] input)
        {
            if (input != null && input.Length > 0)
            {
                // Space trimming in each string
                // Removing empty string element
                // Converting To Upper case each string
                var temporaryString = input.Select(i => i.Trim()).ToArray().
                    Select(i => i.ToUpper()).ToArray().
                    Where(x => !string.IsNullOrEmpty(x)).ToArray();

                return temporaryString;
            }
            return input;
        }
    }
}
