using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;

namespace BookShop.Data.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<IEnumerable<Book>> GetBooks(string bookName);
        Task<Book> GetBook(int bookId);
        Task<bool> Save();
        bool BookExists(int bookId);
        bool BookExists(Book book);
        void AddBook(Book book);
        void DeleteBook(int bookId);
        void UpdateBook(Book book);
    }
}
