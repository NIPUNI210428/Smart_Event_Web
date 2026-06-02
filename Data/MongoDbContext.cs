using MongoDB.Driver;
using Smart_Event_Web.Models;

namespace Smart_Event_Web.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            
            _database = client.GetDatabase("SmartEvents");
        }

        public IMongoCollection<T> GetCollection<T>(string name) => _database.GetCollection<T>(name);
    }
}
