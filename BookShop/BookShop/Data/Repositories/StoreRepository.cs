using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data.Interfaces;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data.Repositories
{
    public class StoreRepository : IStoreRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public StoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            return await _context.Stores.Include(x => x.Book).Include(x => x.Publisher).ToListAsync();
        }

        public async Task<Store> GetStore(int storeID)
        {
            return await _context.Stores.SingleOrDefaultAsync(x => x.Id == storeID);
        }

        public bool StoreExists(int storeID)
        {
            return _context.Stores.Any(e => e.Id == storeID);
        }

        public bool StoreExists(Store store)
        {
            return _context.Stores.Any(e => e.Amount == store.Amount &&
                                            e.Price == store.Price);
        }

        public void AddStore(Store store)
        {
            _context.Stores.Add(store);
        }

        public void DeleteStore(int storeID)
        {
            Store store = _context.Stores.Find(storeID);
            _context.Stores.Remove(store);
        }

        public void UpdateStore(Store store)
        {
            _context.Update(store);
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
