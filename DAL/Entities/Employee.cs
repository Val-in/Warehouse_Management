using Core.Enums;

namespace DAL.Entities;

public class Employee //сущности, которые соответсвуют таблицам в БД и отображаются в models 
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Department { get; set; }  
    
    public Warehouse Warehouse { get; set; }
    public int WarehouseId { get; set; }
    public UserRole Role { get; set; }
    
    public ICollection<Order> Orders { get; set; } //навигационное свойство для связи с order в репозитории
    
    public string Email { get; set; }

    public string FullName
    {
        get => $"{FirstName} {LastName}";
    }
}