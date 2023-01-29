using EmployeesMiniApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesMiniApp.ConsoleUI
{
    internal class CommandExecuter : ICommandExecuter
    {
        private readonly EmployeesService _employeesService;
        private readonly string _helpText = 
            "get-all --- get all employees\n" +
            "get [surname] --- get employee\n" +
            "add [first name] [second name] [salary] --- add new employee\n" +
            "change-salary [surname] [new salary] --- change salary for an employee\n" +
            "remove [surname] --- remove an employee\n";
            

        public CommandExecuter(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public string ExecuteCommand(string command)
        {
            var words = command.Split(' ');

            if (words.Length == 1 && words[0] == "exit")
            {
                return "Program finished";
            }

            switch (words[0])
            {
                case "help":
                    return _helpText;

                case "get-all":
                    return GetAll();

                case "get":
                    if (words.Length == 2)
                    {
                        return Get(words[1]);
                    }

                    return "Failed: invalid command";

                case "add":
                    if (words.Length == 4)
                    {
                        return Add(words[1], words[2], words[3]);
                    }

                    return "Failed: invalid command";

                case "change-salary":
                    if (words.Length == 3)
                    {
                        return ChangeSalary(words[1], words[2]);
                    }

                    return "Failed: invalid command";

                case "remove":
                    if (words.Length == 2)
                    {
                        return Remove(words[1]);
                    }

                    return "Failed: invalid command";
                default:
                    return "Failed: invalid command";
            }
        }

        private string Get(string lastName)
        {
            Employee? employee = _employeesService.GetAll().Where(e => e.LastName == lastName).FirstOrDefault();
            if (employee == null)
            {
                return "Failed: employee not found";
            }

            return employee.ToString();
        }

        private string GetAll()
        {
            var employees = _employeesService.GetAll();
            StringBuilder toShow = new StringBuilder();
            foreach (var employee in employees)
            {
                toShow.Append(employee.ToString());
                toShow.Append('\n');
            }

            return toShow.ToString();
        }

        private string Add(string firstName, string lastName, string salaryString)
        {
            if (int.TryParse(salaryString, out int salary))
            {
                _employeesService.Add(new Employee() { FirstName = firstName, LastName = lastName, Salary = salary});
                return "Employee added\n";
            }

            return "Failed: invalid salary\n";
        }

        private string Remove(string lastName)
        {
            if (_employeesService.Remove(lastName))
            {
                return "Emplpyee removed\n";
            }

            return "Failed: employee not found\n";
        }

        private string ChangeSalary(string lastName, string salaryString)
        {
            if (int.TryParse(salaryString, out int salary))
            {
                if (_employeesService.UpdateSalary(lastName, salary))
                {
                    return "Salary updated\n";
                }

                return "Failed: employee not found\n";
            }  

            return "Failed: salary is invalid";
        }
    }
}
