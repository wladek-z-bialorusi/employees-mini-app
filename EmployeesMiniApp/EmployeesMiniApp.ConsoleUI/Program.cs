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
            Console.WriteLine("Enter \"help\" for a list of commands\n");
            while (true )
            {
                command = Console.ReadLine();
                Console.WriteLine(commandExecuter.ExecuteCommand(command));
                if (command == "Program finished")
                {
                    return;
                }
            }
        }
    }
}