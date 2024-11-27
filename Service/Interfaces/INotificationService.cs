using Lab9.Domain;

namespace Lab9.Service.Interfaces
{
    public interface INotificationService
    {
        bool NotifyUsers(Category category, string title, string message);
    }
}