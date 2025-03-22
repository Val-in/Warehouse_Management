using Core.Enums;

namespace Core.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Department { get; set; }  
    
    public Warehouse Warehouse { get; set; }
    public Guid WarehouseId { get; set; }
    public UserRole Role { get; set; }
}