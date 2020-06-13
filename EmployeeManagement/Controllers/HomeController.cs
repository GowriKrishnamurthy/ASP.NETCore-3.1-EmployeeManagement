using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController
    {
        private readonly IEmployeeService employeeRepository;
        
        // Constructor Injection
        public HomeController(IEmployeeService employeeRepository)
        { 
            this.employeeRepository = employeeRepository;
        }

        public string Index()
        {
            return employeeRepository.GetEmployee(1).Name;
        }
    }
}
