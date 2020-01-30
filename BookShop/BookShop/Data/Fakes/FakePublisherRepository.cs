using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data.Interfaces;
using BookShop.Models;

namespace BookShop.Data.Fakes
{
    public class FakePublisherRepository : IPublisherRepository
    {
        public List<Publisher> Publishers = new List<Publisher>();

        public async Task<IEnumerable<Publisher>> GetPublishers()
        {
            return await Task.Run(() => Publishers);
        }

        public async Task<IEnumerable<Publisher>> GetPublishers(string publisherName)
        {
            return await Task.Run(() => Publishers.Where(x => x.Name.ToLower().Contains(publisherName.ToLower())));
        }

        public async Task<Publisher> GetPublisher(int PublisherId)
        {
            return await Task.Run(() => Publishers.FirstOrDefault(x => x.Id == PublisherId));
        }

        public bool PublisherExists(int id)
        {
            return Publishers.Any(e => e.Id == id);
        }

        public bool PublisherExists(Publisher publisher)
        {
            return Publishers.Any(e => e.Name == publisher.Name);
        }

        public void AddPublisher(Publisher publisher)
        {
            Publishers.Add(publisher);
        }

        public void DeletePublisher(int publisherId)
        {
            Publisher publisher = Publishers.FirstOrDefault(x => x.Id == publisherId);
            Publishers.Remove(publisher);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            var p = Publishers.FirstOrDefault(x => x.Id == publisher.Id);
            p = publisher;
        }

        public async Task<bool> Save()
        {
            return await Task.Run(() => true);
        }
    }
}
