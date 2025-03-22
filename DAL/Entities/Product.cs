namespace DAL.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    
    public Guid OrderId { get; set; }

    public int WarehouseId { get; set; }
    
    public Warehouse Warehouse { get; set; }

}