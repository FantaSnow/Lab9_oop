using Lab9.Service.Interfaces;
using Lab9.Service.Servises;
using Lab9.Service.Servises.Seeders;
using Microsoft.Extensions.DependencyInjection;

namespace Lab9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IUserService, UserService>()
                .AddSingleton<IBookService, BookService>()
                .AddSingleton<ICategoryService, CategoryService>()
                .AddSingleton<IEmailService, EmailService>()
                .AddSingleton<INotificationService, NotificationService>()
                .BuildServiceProvider();

            var userService = serviceProvider.GetService<IUserService>();
            var bookService = serviceProvider.GetService<IBookService>();
            var categoryService = serviceProvider.GetService<ICategoryService>();
            var notificationService = serviceProvider.GetService<INotificationService>();
            
            ILibraryManager libraryManager = new LibraryManager(userService, bookService, categoryService, notificationService);
            ISeeder seeder = new Seeder(categoryService, userService, bookService);
            seeder.InitializeTestData();

            while (true)
            {
                Console.WriteLine("\n1. Manage Users\n2. Manage Books\n3. Exit");
                Console.Write("Choose an option: ");
                if (Enum.TryParse<EntityType>(Console.ReadLine(), out var entityType))
                    switch (entityType)
                    {
                        case EntityType.Users:
                            ManageUsers(libraryManager);
                            break;
                        case EntityType.Books:
                            ManageBooks(libraryManager);
                            break;
                        case EntityType.Exit:
                            return;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
            }
        }

        private static void ManageUsers(ILibraryManager libraryManager)
        {
            Console.WriteLine("\n1. Add User\n2. Edit User\n3. Delete User\n4. List All Users\n5. Back");
            Console.Write("Choose an option: ");
            if (Enum.TryParse<UserAction>(Console.ReadLine(), out var userAction))
                switch (userAction)
                {
                    case UserAction.Add:
                        Console.Write("Enter user name: ");
                        var name = Console.ReadLine();
                        Console.Write("Enter user email: ");
                        var email = Console.ReadLine();
                        libraryManager.AddUser(name, email);
                        break;
                    case UserAction.Edit:
                        Console.Write("Enter user ID to edit: ");
                        if (int.TryParse(Console.ReadLine(), out var id))
                        {
                            Console.Write("Enter new name: ");
                            var newName = Console.ReadLine();
                            Console.Write("Enter new email: ");
                            var newEmail = Console.ReadLine();
                            libraryManager.EditUser(id, newName, newEmail);
                        }
                        break;
                    case UserAction.Delete:
                        Console.Write("Enter user ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out var delId))
                        {
                            libraryManager.DeleteUser(delId);
                        }
                        break;
                    case UserAction.ListAll:
                        var users = libraryManager.GetAllUsers();
                        if (users.Count > 0)
                            foreach (var user in users)
                                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
                        else
                            Console.WriteLine("No users found.");
                        break;
                    case UserAction.Back:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
        }

        private static void ManageBooks(ILibraryManager libraryManager)
        {
            Console.WriteLine("\n1. Add Book\n2. Edit Book\n3. Delete Book\n4. List All Books\n5. Back");
            Console.Write("Choose an option: ");
            if (Enum.TryParse<BookAction>(Console.ReadLine(), out var bookAction))
                switch (bookAction)
                {
                    case BookAction.Add:
                        Console.Write("Enter book title: ");
                        var title = Console.ReadLine();
                        Console.Write("Enter book author: ");
                        var author = Console.ReadLine();
                        Console.Write("Enter category name: ");
                        var categoryName = Console.ReadLine();
                        libraryManager.AddBook(title, author, categoryName);
                        break;
                    case BookAction.Edit:
                        Console.Write("Enter book ID to edit: ");
                        if (int.TryParse(Console.ReadLine(), out var id))
                        {
                            Console.Write("Enter new title: ");
                            var newTitle = Console.ReadLine();
                            Console.Write("Enter new author: ");
                            var newAuthor = Console.ReadLine();
                            Console.Write("Enter new category name: ");
                            var newCategoryName = Console.ReadLine();
                            libraryManager.EditBook(id, newTitle, newAuthor, newCategoryName);
                        }
                        break;
                    case BookAction.Delete:
                        Console.Write("Enter book ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out var delId))
                        {
                            libraryManager.DeleteBook(delId);
                        }
                        break;
                    case BookAction.ListAll:
                        var books = libraryManager.GetAllBooks();
                        if (books.Count > 0)
                            foreach (var book in books)
                                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Category: {book.Category.Name}");
                        else
                            Console.WriteLine("No books found.");
                        break;
                    case BookAction.Back:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
        }

        private enum EntityType
        {
            Users = 1,
            Books,
            Exit
        }

        private enum UserAction
        {
            Add = 1,
            Edit,
            Delete,
            ListAll,
            Back
        }

        private enum BookAction
        {
            Add = 1,
            Edit,
            Delete,
            ListAll,
            Back
        }
    }
}
