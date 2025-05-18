using Core.Interfaces;
using Core.Models;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Помещает продукт айди на склад айди. 
    /// </summary>
    /// <param name="productId">айди продукта</param>
    /// <param name="warehouseId">айди склада</param>
    /// <exception cref="InvalidOperationException">ошибка</exception>
    public void SetOrderInStock(int productId, int warehouseId) 
    {
        var product = _context.Products.Find(productId) ?? throw new InvalidOperationException($"Product with id {productId} is not found");
        product.WarehouseId = warehouseId;
        product.Quantity += 1;
        _context.SaveChanges();
    }

    public void EmptyOrderInStock(int productId, int warehouseId)
    {
        var product = _context.Products.Find(productId) ?? throw new InvalidOperationException($"Product with id {productId} is not found");
        product.WarehouseId = 0;
        product.Quantity = Math.Max(0, product.Quantity - 1);
        _context.SaveChanges();
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        var productDb = _context.Products.Find(product.Id) ?? throw new InvalidOperationException($"Product with id {product.Id} is not found");
        
        productDb.Price = product.Price;
        productDb.Quantity = product.Quantity;
        productDb.Name = product.Name;
        productDb.WarehouseId = product.WarehouseId;
        productDb.Description = product.Description;
        productDb.Id = product.Id;
        productDb.OrderId = product.OrderId;
        _context.SaveChanges();
        
    }

    public void DeleteProduct(int productId)
    {
        var product = _context.Products.Find(productId) ?? throw new InvalidOperationException($"Product with id {productId} is not found");
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public List<Product> GetAllProducts() //через db обращаемся к entities, если без db, то обращаемся к модели
    {
        return _context.Products.Include(x => x.Warehouse).ToList();
    }
}