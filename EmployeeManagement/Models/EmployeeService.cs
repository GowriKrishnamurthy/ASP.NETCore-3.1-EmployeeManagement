using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> employeeList;
        public EmployeeService()
        {
            employeeList = new List<Employee>() 
            {
                 new Employee() { Id = 1, Name = "Mary", Department = Department.HR, Email = "mary@something.com" },
                 new Employee() { Id = 2, Name = "John", Department = Department.IT, Email = "john@something.com" },
                 new Employee() { Id = 3, Name = "Sam", Department = Department.Payroll, Email = "sam@something.com" },
            };

        }
        public Employee GetEmployee(int Id)
        {
            return employeeList.FirstOrDefault(emp => emp.Id == Id);
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return employeeList;
        }
        public Employee Add(Employee employee)
        {
            employee.Id = employeeList.Max(e => e.Id) + 1;
            employeeList.Add(employee);
            return employee;
        }
    }
}
