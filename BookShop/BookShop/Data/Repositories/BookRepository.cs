using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;
using BookShop.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data.Repositories
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooks(string bookName)
        {
            return await _context.Books.Where(n => n.Name.ToLower().Contains(bookName.ToLower())).ToListAsync();
        }

        public async Task<Book> GetBook(int bookID)
        {
            return await _context.Books.SingleOrDefaultAsync(x => x.Id == bookID);
        }

        public bool BookExists(int bookID)
        {
            return _context.Books.Any(e => e.Id == bookID);
        }

        public bool BookExists(Book book)
        {
            return _context.Books.Any(e => e.Name == book.Name && e.Genre == book.Genre && e.Year == book.Year);
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void DeleteBook(int bookId)
        {
            Book book = _context.Books.Find(bookId);
            _context.Books.Remove(book);
        }

        public void UpdateBook(Book book)
        {
            _context.Update(book);
        }

        public async Task<bool> Save()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
