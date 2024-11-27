using System;
using System.Collections.Generic;
using Lab9.Domain;
using Lab9.Service.Interfaces;

namespace Lab9
{
    public class LibraryManager : ILibraryManager
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly INotificationService _notificationService;

        public LibraryManager(IUserService userService, IBookService bookService, ICategoryService categoryService,
            INotificationService notificationService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        public bool AddUser(string name, string email)
        {
            var user = new User { Name = name, Email = email };
            if (_userService.Register(user))
            {
                Console.WriteLine("User added successfully.");
                return true;
            }
                Console.WriteLine("Failed to add user.");
                return false;
        }

        public bool EditUser(int id, string newName, string newEmail)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return false;
            }

            user.Name = newName;
            user.Email = newEmail;

            if (!_userService.EditUser(user))
            {
                Console.WriteLine("Failed to edit user.");
                return false;
            }

            Console.WriteLine("User edited successfully.");

            return true;
        }

        public bool DeleteUser(int id)
        {
            if (!_userService.DeleteUser(id))
            {
                Console.WriteLine("Failed to delete user.");
                return false;
            }

            Console.WriteLine("User deleted successfully.");
            return true;
        }

        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        public bool AddBook(string title, string author, string categoryName)
        {
            var category = _categoryService.GetAllCategory().Find(c => c.Name == categoryName);
            if (category == null)
            {
                Console.WriteLine("Category was not found.");
                return false;
            }

            var book = new Book { Title = title, Author = author, Category = category };
            if (!_bookService.AddBook(book))
            {
                Console.WriteLine("Failed to add book.");
                return false;
            }

            _notificationService.NotifyUsers(category, "New book added.",
                $"New book '{book.Title}' added with category '{category.Name}'");
            Console.WriteLine("Book added successfully.");
            return true;
        }

        public bool EditBook(int id, string newTitle, string newAuthor, string newCategoryName)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return false;
            }

            book.Title = newTitle;
            book.Author = newAuthor;
            book.Category.Name = newCategoryName;

            if (_bookService.EditBook(book))
            {
                Console.WriteLine("Failed to edit book.");
                return false;
            }

            Console.WriteLine("Book edited successfully.");
            return true;
        }

        public bool DeleteBook(int id)
        {
            if (!_bookService.DeleteCategory(id))
            {
                Console.WriteLine("Failed to delete book.");
                return false;
            }

            Console.WriteLine("Book deleted successfully.");
            return true;
        }

        public List<Book> GetAllBooks()
        {
            return _bookService.GetAllCategory();
        }
    }
}