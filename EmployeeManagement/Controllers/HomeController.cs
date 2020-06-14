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
        private readonly IEmployeeService employeeService;
        
        // Constructor Injection
        public HomeController(IEmployeeService employeeService)
        { 
            this.employeeService = employeeService;
        }
        public ViewResult Index()
        {
            IEnumerable<Employee> empList = employeeService.GetAllEmployee();

            return View(empList);
        }

        public ViewResult Details(int id)
        {
            Employee emp = employeeService.GetEmployee(id);

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel() { 
                Employee = emp,
                PageTitle = "Employee Details"
            };          
            return View(homeDetailsViewModel);
        }
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employeeService.GetEmployee(id ?? 1),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }
        public string Details(int? id, string name)
        {
            return "id = " + id.Value.ToString() + " and name = " + name;
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Employee employee)
        {
            Employee newEmployee = employeeService.Add(employee);
            return RedirectToAction("details", new { id = newEmployee.Id });
        }
    }
}
