﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesMiniApp.ConsoleUI
{
    internal interface ICommandExecuter
    {
        string ExecuteCommand(string command);
    }
}
