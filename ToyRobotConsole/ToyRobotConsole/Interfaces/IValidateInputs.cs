using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotConsole.Interfaces
{
    public interface IValidateInputs
    {
        bool ValidateInput(string[] commands);
        string[] FormatInput(string[] input);
    }
}
