using DAL.Entities;

namespace DAL.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;   
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }
    
    public void UpdateProduct(Product product)
    {
        if (product != null)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
    
    public void DeleteProduct(int productId)
    {
        var existingProduct = _context.Products.Find(productId);
        if (productId != null)
        {
            _context.Products.Remove(existingProduct);
            _context.SaveChanges();
        }
    }

    public Product GetProductById(int productId)
    {
        return _context.Products.FirstOrDefault(p => p.Id == productId);
    }
    
    public List<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }
    
}