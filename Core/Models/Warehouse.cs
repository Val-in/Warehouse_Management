namespace Core.Models;

public class Warehouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    
    public Guid ProductId { get; set; }
    
    public List<Employee> Employees { get; set; }
    
    
    public Guid OrderId { get; set; }
}