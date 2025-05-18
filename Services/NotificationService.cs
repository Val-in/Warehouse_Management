using System.Net;
using System.Net.Mail;
using Core.Interfaces;
using DAL;
using DAL.Entities;
using Order = Core.Models.Order;

namespace Services;

public class NotificationService : INotificationService //после получения данных из БД здесь мы будем реализововать логику
{
    public readonly AppDbContext _context;

    public NotificationService(AppDbContext context)
    {
        _context = context;
    }

    // 1) самый высокий уровень: уведомление по заказу
    public void SendOrderNotification(Order order)
    {
        // вытаскиваем email юзера (предполагается, что у Core.Models.Order есть Customer = userId)
        var user = _context.Employees.Find(order.Customer)
                   ?? throw new InvalidOperationException($"User {order.Customer} not found");
            
        var subject = "Ваш заказ обновлён";
        var body    = $"Заказ #{order.OrderId}: статус {order.OrderStatus}";

        SendEmail(user.Email, subject, body);
        SendInAppNotification(user.Id, $"Заказ #{order.OrderId} теперь {order.OrderStatus}");
    }

    // 2) почтовое уведомление
    public void SendEmail(string to, string subject, string message)
    {
        var smtp = new SmtpClient("smtp.yourserver.com")
        {
            Port          = 587,
            Credentials   = new NetworkCredential("login@domain.com", "password"),
            EnableSsl     = true
        };

        var mail = new MailMessage
        {
            From        = new MailAddress("login@domain.com"),
            Subject     = subject,
            Body        = message,
            IsBodyHtml  = false
        };
        mail.To.Add(to);

        smtp.Send(mail);
    }

    // 3) внутренняя запись в БД
    public void SendInAppNotification(int userId, string message)
    {
        var note = new Notification
        {
            UserId    = userId,
            Message   = message,
            CreatedAt = DateTime.UtcNow
        };
        _context.Notifications.Add(note);
        _context.SaveChanges();
    }
    
    public List<Core.Models.Notification> GetAllNotifications()
    {
        return _context.Notifications
            .OrderByDescending(n => n.CreatedAt)
            .Select(n => new Core.Models.Notification {
                Id        = n.Id,
                UserId    = n.UserId,
                Message   = n.Message,
                CreatedAt = n.CreatedAt
            })
            .ToList();
    }

}
