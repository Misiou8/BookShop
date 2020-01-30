using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data.Interfaces;
using BookShop.Models;

namespace BookShop.Data.Fakes
{
    public class FakeBookRepository : IBookRepository
    {
        public List<Book> Books = new List<Book>();

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await Task.Run(() => Books);
        }

        public async Task<IEnumerable<Book>> GetBooks(string bookName)
        {
            return await Task.Run(() => Books.Where(x => x.Name.ToLower().Contains(bookName.ToLower())));
        }

        public async Task<Book> GetBook(int BookId)
        {
            return await Task.Run(() => Books.FirstOrDefault(x => x.Id == BookId));
        }

        public bool BookExists(int id)
        {
            return Books.Any(e => e.Id == id);
        }

        public bool BookExists(Book book)
        {
            return Books.Any(e => e.Name == book.Name);
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void DeleteBook(int bookId)
        {
            Book book = Books.FirstOrDefault(x => x.Id == bookId);
            Books.Remove(book);
        }

        public void UpdateBook(Book book)
        {
            var b = Books.FirstOrDefault(x => x.Id == book.Id);
            b = book;
        }

        public async Task<bool> Save()
        {
            return await Task.Run(() => true);
        }

    }
}
