using Core.Enums;
using Core.Models;

namespace Core.Interfaces;

public interface IOrderService
{
     void CreateOrder(Order order);
     void CancelOrder(Order order); 
     
     List<Order> GetOrdersByStatus(OrderStatus status);
     void UpdateOrderStatus(Guid orderId,OrderStatus status);
     
     void OrderSent(Order order);
     void SetOrderCompleted(Order order);

}