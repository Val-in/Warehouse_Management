using Core.Enums;

namespace DAL.Entities;

public class Order
{
    public Guid OrderId { get; set; }
    public DateTime CreateDate { get; set;}
    public DateTime? DeliveryDate { get; set;}
    
    public int ProductId { get; set; }
    public int EmployeeId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public int Customer  { get; set; }
    
    public List<Warehouse> WarehouseId { get; set; }
    
    public List<Product> ProductIds { get; set; }
    
    public Product Product { get; set; }
    public Employee Employee { get; set; }
}