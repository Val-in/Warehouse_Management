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
            var entity = new DAL.Entities.Order
            {
                OrderId      = order.OrderId == Guid.Empty ? Guid.NewGuid() : order.OrderId,
                CreateDate   = order.CreateDate,
                DeliveryDate = order.DeliveryDate,
                OrderStatus  = order.OrderStatus,
                Customer     = order.Customer
                // при необходимости: ProductId, EmployeeId, списки и т.д.
            };
            _context.Orders.Add(entity);
            _context.SaveChanges();
            order.OrderId = entity.OrderId;
        }

        public void CancelOrder(Order order)
        {
            var entity = _context.Orders.Find(order.OrderId)
                      ?? throw new InvalidOperationException($"Order {order.OrderId} not found");
            entity.OrderStatus = OrderStatus.Canceled;
            _context.SaveChanges();
        }

        public List<Order> GetOrdersByStatus(OrderStatus status)
        {
            return _context.Orders
                      .Where(o => o.OrderStatus == status)
                      .Select(o => new Order
                      {
                          OrderId      = o.OrderId,
                          CreateDate   = o.CreateDate,
                          DeliveryDate = o.DeliveryDate,
                          OrderStatus  = o.OrderStatus,
                          Customer     = o.Customer
                      })
                      .ToList();
        }

        public void UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            var entity = _context.Orders.Find(orderId)
                      ?? throw new InvalidOperationException($"Order {orderId} not found");
            entity.OrderStatus = status;
            _context.SaveChanges();
        }

        public void OrderSent(Order order)
        {
            var entity = _context.Orders.Find(order.OrderId)
                      ?? throw new InvalidOperationException($"Order {order.OrderId} not found");
            entity.OrderStatus = OrderStatus.InProgress;
            _context.SaveChanges();
        }

        public void SetOrderCompleted(Order order)
        {
            var entity = _context.Orders.Find(order.OrderId)
                      ?? throw new InvalidOperationException($"Order {order.OrderId} not found");
            entity.OrderStatus = OrderStatus.Completed;
            _context.SaveChanges();
        }
}