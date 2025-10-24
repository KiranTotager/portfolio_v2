using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Portfolio.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase mongoDatabase;
        public MongoDbContext(IOptions<MongoDbSettings> mongoDbSettings)
        {
           var Client=new MongoClient(mongoDbSettings.Value.ConnectionString);
            mongoDatabase=Client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        }
        public IMongoCollection<T> GetCollecgtion<T>(string collectionName)
        {
            return mongoDatabase.GetCollection<T>(collectionName);
        }
    }
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
