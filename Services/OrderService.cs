using Core.Enums;
using Core.Interfaces;
using Core.Models;
using DAL;

namespace Services;

public class OrderService : IOrderService
{
    public readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }


    public void CreateOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public void CancelOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public List<Order> GetOrdersByStatus(OrderStatus status)
    {
        throw new NotImplementedException();
    }

    public void UpdateOrderStatus(Guid orderId, OrderStatus status)
    {
        throw new NotImplementedException();
    }

    public void OrderSent(Order order)
    {
        throw new NotImplementedException();
    }

    public void SetOrderCompleted(Order order)
    {
        throw new NotImplementedException();
    }
}