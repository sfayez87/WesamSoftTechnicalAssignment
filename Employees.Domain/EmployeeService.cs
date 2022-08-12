using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Employees.Domain
{
    public class EmployeeService
    {
        private readonly EmployeesDBEntities _context;
        public EmployeeService():this(new EmployeesDBEntities())
        {

        }
        public EmployeeService(EmployeesDBEntities context)
        {
            _context = context;
        }
        public IQueryable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }
        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }
        public IQueryable<Employee> GetEmployeesByFirstName(string EmpFirstName)
        {
            return _context.Employees.Where(emp => emp.FirstName == EmpFirstName);
        }
        public IQueryable<Employee> GetEmployeesByBirthdate(DateTime? StartEmpBirthDate, DateTime? EndEmpBirthDate)
        {
            return _context.Employees.Where(emp=> emp.BirthDate.Value >=StartEmpBirthDate.Value && emp.BirthDate.Value <=EndEmpBirthDate.Value);
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public void Edit(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
