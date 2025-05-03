
using Core.Interfaces;
using Core.Models;
using DAL;

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
        throw new NotImplementedException();
    }

    public void AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAllProducts()
    {
        throw new NotImplementedException();
    }
}