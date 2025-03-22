using DAL.Entities;

namespace DAL.Repositories;

public interface IProductRepository
{
    void AddProduct(Product product);
    void UpdateProduct(Product productId);
    void DeleteProduct(int productId); 
    Product GetProductById(int productId);
    List<Product> GetAllProducts();
}