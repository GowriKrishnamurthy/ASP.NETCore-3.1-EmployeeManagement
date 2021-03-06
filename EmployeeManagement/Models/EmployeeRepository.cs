﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private List<Employee> employeeList;
        public EmployeeRepository()
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

        public Employee Delete(int Id)
        {
            Employee employee = employeeList.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
                employeeList.Remove(employee);

            return employee;
        }
        public Employee Update(Employee employeeChanges)
        {
            Employee employee = employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }
    }
}
