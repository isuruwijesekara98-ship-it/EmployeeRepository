using EmployeeApp.Models;

namespace EmployeeApp.Data.Abstract
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllEmployees();
        Employee? GetEmployeeById(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
