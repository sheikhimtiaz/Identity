using Identity.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Identity.Services
{
    public class MongoService
    {
        private readonly IMongoCollection<User> _books; 

        public MongoService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<User>(settings.BooksCollectionName);
        }

        public List<User> Get() =>
            _books.Find(user => true).ToList();

        public User Get(string id) =>
            _books.Find<User>(user => user._id == id).FirstOrDefault();

        public User Create(User user)
        {
            _books.InsertOne(user);
            return user;
        }

        public void Update(string id, User bookIn) =>
            _books.ReplaceOne(user => user._id == id, bookIn);

        public void Remove(User bookIn) =>
            _books.DeleteOne(user => user._id == bookIn._id);

        public void Remove(string id) => 
            _books.DeleteOne(user => user._id == id);
    }
}