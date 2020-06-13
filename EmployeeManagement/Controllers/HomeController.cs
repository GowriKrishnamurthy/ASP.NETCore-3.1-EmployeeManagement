using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService employeeRepository;
        
        // Constructor Injection
        public HomeController(IEmployeeService employeeRepository)
        { 
            this.employeeRepository = employeeRepository;
        }
        public ViewResult Index()
        {
            IEnumerable<Employee> empList = employeeRepository.GetAllEmployee();

            return View(empList);
        }

        public ViewResult Details()
        {
            Employee emp = employeeRepository.GetEmployee(2);

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel() { 
                Employee = emp,
                PageTitle = "Employee Details"
            };          
            return View(homeDetailsViewModel);
        }
    }
}
