using Core.Interfaces;
using Core.Models;
using DAL;

namespace Services;

public class NotificationService : INotificationService //после получения данных из БД здесь мы будем реализововать логику
{
    public readonly AppDbContext _context;

    public NotificationService(AppDbContext context)
    {
        _context = context;
    }

    public void SendOrderNotification(Order order)
    {
        var orderToSend = _context.Orders.Find(order.OrderId) ?? throw new InvalidOperationException($"Order with id {order.OrderId} is not found");
    }

    public void SendEmail(string to, string subject, string message)
    {
        
    }

    public void SendInAppNotification(int userId, string message)
    {
        throw new NotImplementedException();
    }
}