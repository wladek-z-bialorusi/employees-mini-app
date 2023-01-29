using EmployeesMiniApp.DAL;

namespace EmployeesMiniApp.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommandExecuter commandExecuter = new CommandExecuter(
                new EmployeesService(
                    new EmployeeRepository(
                        new EmployeesContext())
                    )
                );

            string command;
            string result;
            Console.WriteLine("Enter \"help\" for a list of commands\n");
            while (true )
            {
                command = Console.ReadLine();
                result = commandExecuter.ExecuteCommand(command);
                Console.WriteLine(result);
                if (result == "Program finished")
                {
                    return;
                }
            }
        }
    }
}