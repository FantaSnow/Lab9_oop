using Lab9.Domain;
using Lab9.Service.Interfaces;

namespace Lab9.Service.Servises
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        public NotificationService(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        public bool NotifyUsers(Category category, string title ,string message)
        {
            var users = _userService.GetUsersSubscribedToCategory(category);
            if (users == null || users.Count == 0)
                return false;

            foreach (var user in users)
                _emailService.SendEmail(user.Email, title, message);
            return true;
        }
        
    }
}