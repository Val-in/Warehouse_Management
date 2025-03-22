using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class EmployeeRepository : IEmployeeRepository // методы для работы с данными
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public void AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }
    
    public void UpdateEmployee(Employee employee)
    {
        if (employee != null)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }
    }
    
    public void DeleteEmployee(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Remove(employee);
            _context.SaveChanges();
        }
    }
    
    public Employee GetEmployeeById(int id)
    {
        return _context.Employees.FirstOrDefault(e => e.Id == id);
    }
    
    public IEnumerable<Employee> GetAllEmployees()
    {
        return _context.Employees.ToList();
    }
    
}