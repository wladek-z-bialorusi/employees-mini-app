using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesMiniApp.DAL
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private EmployeesContext _employeesContext;

        public EmployeeRepository(EmployeesContext employeesContext)
        {
            _employeesContext = employeesContext;
        }

        public void Add(Employee entity)
        {
            _employeesContext.Employees.Add(entity);
            _employeesContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            foreach (var e in _employeesContext.Employees)
            {
                yield return e;
            }
        }

        public Employee? GetById(int id)
        {
            return _employeesContext.Employees.Where(e => e.Id == id).FirstOrDefault();
        }

        public void Remove(Employee employee)
        {
            _employeesContext.Employees.Remove(employee);
            _employeesContext.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _employeesContext.Employees.Update(employee);
            _employeesContext.SaveChanges();
        }
    }
}
