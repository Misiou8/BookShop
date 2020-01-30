using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data.Interfaces;
using BookShop.Models;

namespace BookShop.Data.Fakes
{
    public class FakeStoreRepository : IStoreRepository
    {
        public List<Store> Stores = new List<Store>();

        public async Task<IEnumerable<Store>> GetStores()
        {
            return await Task.Run(() => Stores);
        }

        public async Task<Store> GetStore(int StoreId)
        {
            return await Task.Run(() => Stores.FirstOrDefault(x => x.Id == StoreId));
        }

        public bool StoreExists(int id)
        {
            return Stores.Any(e => e.Id == id);
        }

        public bool StoreExists(Store store)
        {
            return Stores.Any(e => e.Amount == store.Amount &&
                                   e.Price == store.Price);
        }

        public void AddStore(Store store)
        {
            Stores.Add(store);
        }

        public void DeleteStore(int storeId)
        {
            Store store = Stores.FirstOrDefault(x => x.Id == storeId);
            Stores.Remove(store);
        }

        public void UpdateStore(Store store)
        {
            var s = Stores.FirstOrDefault(x => x.Id == store.Id);
            s = store;
        }

        public async Task<bool> Save()
        {
            return await Task.Run(() => true);
        }
    }
}
