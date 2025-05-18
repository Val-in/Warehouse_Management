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

    public void AddProduct(Product product) //product из core == entity из DAL
    {
        var entity = new DAL.Entities.Product
        {
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
            WarehouseId = product.WarehouseId,
            Description = product.Description,
            Id = product.Id
        };
        _context.Products.Add(entity);
        _context.SaveChanges();
        product.Id = entity.Id;
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
        return _context.Products
            .Include(p => p.Warehouse)
            .Select(p => new Product
            {
                Id          = p.Id,
                Name        = p.Name,
                Description = p.Description,
                Price       = p.Price,
                Quantity    = p.Quantity,
                WarehouseId = p.WarehouseId,
                OrderId     = p.OrderId
            })
            .ToList();
    }
}