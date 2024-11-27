using System.Collections.Generic;
using Lab9.Domain;

namespace Lab9.Service.Interfaces
{
    public interface ILibraryManager
    {
        bool EditBook(int id, string newTitle, string newAuthor, string newCategoryName);
        bool AddUser(string name, string email);
        bool EditUser(int id, string newName, string newEmail);
        bool DeleteUser(int id);
        List<User> GetAllUsers();
        bool AddBook(string title, string author, string categoryName);       
        bool DeleteBook(int id);
        List<Book> GetAllBooks();
    }
}