using EmployeeApp.Data;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Employees()
        {
            return View();
        }

        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult CreateEditEmployee(int? id)
        {
            if (id != null)
            {
                var expenseInDb = _context.Employees.FirstOrDefault(x => x.Id == id);
                return View(expenseInDb);
            }

            return View();
        }

        public IActionResult CreateEditEmployeeForm(Employee model)
        {
            if (model.Id == 0)
            {
                _context.Employees.Add(model);
            }
            else
            {
                _context.Employees.Update(model);
            }

            _context.SaveChanges();

            return RedirectToAction("GetEmployees");
        }

        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.SingleOrDefault(emp => emp.Id == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("GetEmployees");
        }
    }
}
