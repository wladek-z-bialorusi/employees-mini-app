using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesMiniApp.DAL
{
    internal class EmployeesContextFactory : IDesignTimeDbContextFactory<EmployeesContext>
    {
        public EmployeesContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<EmployeesContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;
            return new EmployeesContext(options);

        }
    }
}
