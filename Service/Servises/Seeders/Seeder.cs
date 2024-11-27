using Lab9.Domain;
using Lab9.Service.Interfaces;

namespace Lab9.Service.Servises.Seeders;

public class Seeder : ISeeder
{
    private ICategoryService _categoryService;
    private IUserService _userService;
    private IBookService _bookService;
    
    public Seeder(ICategoryService categoryService, IUserService userService, IBookService bookService)
    {
        _categoryService = categoryService;
        _userService = userService;
        _bookService = bookService;
    }

    public void InitializeTestData()
    {
        var fictionCategory = new Category { Id = 1, Name = "Fiction" };
        var scienceCategory = new Category { Id = 2, Name = "Science" };
        
        _categoryService.AddCategory(fictionCategory);
        _categoryService.AddCategory(scienceCategory);

        var user1 = new User { Id = 1, Name = "Alice", Email = "alice@example.com", Books = new List<Book>() };
        var user2 = new User { Id = 2, Name = "Bob", Email = "bob@example.com", Books = new List<Book>() };

        _userService.Register(user1);
        _userService.Register(user2);

        var book1 = new Book
            { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Category = fictionCategory };
        var book2 = new Book
            { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Category = fictionCategory };
        var book3 = new Book
            { Id = 3, Title = "A Brief History of Time", Author = "Stephen Hawking", Category = scienceCategory };

        _bookService.AddBook(book1);
        _bookService.AddBook(book2);
        _bookService.AddBook(book3);

        user1.Books.Add(book1);
        user1.Books.Add(book2);
        user2.Books.Add(book3);
    }
}