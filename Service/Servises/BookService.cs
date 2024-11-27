using System.Collections.Generic;
using System.Linq;
using Lab9.Domain;
using Lab9.Service.Interfaces;

namespace Lab9.Service.Servises
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new List<Book>();
        private int _nextId = 1;

        public BookService()
        {
        }

        public bool AddBook(Book book)
        {
            if (book == null)
                return false;
            book.Id = _nextId++;
            _books.Add(book);
            
            return true;
        }

        public bool EditBook(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (book == null || existingBook == null)
                return false;

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Category = book.Category;
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var category = _books.FirstOrDefault(b => b.Id == id);
            if (category == null)
                return false;
            _books.Remove(category);
            return true;
        }

        public Book GetById(int bookId)
        {
            if (bookId <= 0)
                return null;
            return _books.FirstOrDefault(u => u.Id == bookId);
        }

        public List<Book> GetAllCategory()
        {
            return _books;
        }
    }
}