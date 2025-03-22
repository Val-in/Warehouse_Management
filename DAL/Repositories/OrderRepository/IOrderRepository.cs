using Core.Enums;
using DAL.Entities;

namespace DAL.Repositories;

public interface IOrderRepository 
{
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(int orderId);
    Order GetOrderById(Guid orderId);
    IEnumerable<Order> GetAllOrders();
    IEnumerable<Order> GetOrdersByStatus(OrderStatus status);
}