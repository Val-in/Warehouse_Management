namespace DAL.Entities;

public class Warehouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    
    public Guid ProductId { get; set; }
    
    public ICollection<Employee> Employees { get; set; }
    
    public Guid OrderId { get; set; }
    
    public ICollection<Product> Products { get; set; } //навигационное свойство для связи с product в репозитории
}