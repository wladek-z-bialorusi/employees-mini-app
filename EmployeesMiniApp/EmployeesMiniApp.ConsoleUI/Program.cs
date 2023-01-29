using EmployeesMiniApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeesMiniApp.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<EmployeesContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            CommandExecuter commandExecuter = new CommandExecuter(
                new EmployeesService(
                    new EmployeeRepository(
                        new EmployeesContext(options))
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