using System.Collections.Generic;
using Lab9.Domain;

namespace Lab9.Service.Interfaces
{
    public interface IUserService
    {
        bool Register(User user);
        bool DeleteUser(int userId);
        bool EditUser(User user);
        User GetUser(int userId);
        List<User> GetAllUsers();
        List<User> GetUsersSubscribedToCategory(Category category);
    }
}