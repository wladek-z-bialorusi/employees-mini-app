using EmployeesMiniApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesMiniApp.ConsoleUI
{
    internal class EmployeesService
    {
        private readonly IRepository<Employee> _repository;

        public EmployeesService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public Employee? GetByLastName(string lastName)
        {
            return _repository.GetAll().Where(e => e.LastName == lastName).FirstOrDefault();
        }

        public void Add(Employee employee)
        {
            _repository.Add(employee);
        }

        public bool Remove(string lastName)
        {
            Employee? employeeToRemove = _repository.GetAll().Where(e => e.LastName == lastName).FirstOrDefault();
            if (employeeToRemove != null)
            {
                _repository.Remove(employeeToRemove);
                return true;
            }

            return false;
        }

        public bool UpdateSalary(string lastName, int newSalary)
        {
            Employee? updatedEmployee = _repository.GetAll().Where(e => e.LastName == lastName).FirstOrDefault();
            if (updatedEmployee != null)
            {
                updatedEmployee.Salary = newSalary;
                _repository.Update(updatedEmployee);
                return true;
            }

            return false;
        }
    }
}
