using System.Collections.Generic;
using Lab9.Domain;

namespace Lab9.Service.Interfaces
{
    public interface IBookService
    {
        bool AddBook(Book book);
        bool EditBook(Book book);
        bool DeleteCategory(int id);
        Book? GetById(int id);
        List<Book> GetAllCategory();
    }
}