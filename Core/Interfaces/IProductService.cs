using Core.Models;

namespace Core.Interfaces;

public interface IProductService
{
     void SetOrderInStock(int productId, int warehouseId);
     void EmptyOrderInStock(int productId, int warehouseId);
     void AddProduct(Product product);
     void UpdateProduct(Product product);
     void DeleteProduct(int productId);
     List<Product> GetAllProducts();
}