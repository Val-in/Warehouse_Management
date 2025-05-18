using Core.Models;

namespace Core.Interfaces;

public interface INotificationService //методы, реализованные в программе
{
    void SendOrderNotification(Order order);
    void SendEmail(string to, string subject, string message);
    void SendInAppNotification(int userId, string message);
    
    List<Notification> GetAllNotifications();

}