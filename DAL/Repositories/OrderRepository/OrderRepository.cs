using Core.Enums;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void UpdateOrder(Order order)
    {
        _context.Orders.Update(order);
        _context.SaveChanges();
    }

    public void DeleteOrder(int orderId)
    {
        var existingOrder = _context.Orders.Find(orderId);
        if (existingOrder != null)
        {
            _context.Orders.Remove(existingOrder);
            _context.SaveChanges();
        }
    }

    public Order GetOrderById(Guid orderId)
    {
        return _context.Orders
            .Include(i => i.Product)
            .Include(i => i.Employee)
            .FirstOrDefault(o => o.OrderId == orderId);
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _context.Orders
            .Include(i => i.Product)
            .Include(i => i.Employee)
            .ToList();
    }

    public IEnumerable<Order> GetOrdersByStatus(OrderStatus status)
    {
        return _context.Orders
            .Include(i => i.Product)
            .Include(i => i.Employee)
            .Where(o => o.OrderStatus == status)
            .ToList();
    }
}