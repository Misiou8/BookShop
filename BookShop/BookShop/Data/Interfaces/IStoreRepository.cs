using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;

namespace BookShop.Data.Interfaces
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetStores();
        Task<Store> GetStore(int storeID);
        Task<bool> Save();
        bool StoreExists(int storeID);
        bool StoreExists(Store store);
        void AddStore(Store store);
        void DeleteStore(int storeID);
        void UpdateStore(Store store);
    }
}
