using EmployeeApp.Data;
using EmployeeApp.Data.Abstract;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(AppDbContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Employees()
        {
            return View();
        }

        public IActionResult GetEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }

        public IActionResult CreateEditEmployee(int? id)
        {
            if (id.HasValue)
            {
                var employeeInDb = _employeeRepository.GetEmployeeById(id.Value);
                return View(employeeInDb);
            }

            // If id is null, return an empty Employee object for creation
            return View(new Employee());
        }

        public IActionResult CreateEditEmployeeForm(Employee model)
        {
            if (model.Id == 0)
            {
                _employeeRepository.AddEmployee(model);
            }
            else
            {
                _employeeRepository.UpdateEmployee(model);
            }

            return RedirectToAction("GetEmployees");
        }

        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee != null)
            {
                _employeeRepository.DeleteEmployee(employee);
            }
            return RedirectToAction("GetEmployees");
        }
    }
}
