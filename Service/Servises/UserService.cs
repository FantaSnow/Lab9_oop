
using Lab9.Domain;
using Lab9.Service.Interfaces;

namespace Lab9.Service.Servises
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>();
        private int _nextId = 1;

        public bool Register(User user)
        {
            if (user == null)
                return false;
            user.Id = _nextId++;
            _users.Add(user);
            return true;
        }

        public bool EditUser(User user)
        {
            if (user == null)
                return false;
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Books = user.Books;
            }

            return true;
        }

        public bool DeleteUser(int userId)
        {
            if (userId <= 0)
                return false;

            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return false;

            _users.Remove(user);

            return true;
        }

        public List<User> GetUsersSubscribedToCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Category cannot be null.");

            return _users.Where(user =>
                user.Books != null && user.Books.Any(b => b.Category != null && b.Category.Id == category.Id)).ToList();
        }


        public User GetUser(int userId)
        {
            if (userId <= 0)
                return null;
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }
    }
}