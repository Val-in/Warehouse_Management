using DAL.Entities;

namespace DAL.Repositories;

public interface IEmployeeRepository
{
    void AddEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(int employeeId);
    Employee GetEmployeeById(int employeeId); 
    IEnumerable<Employee> GetAllEmployees();
}