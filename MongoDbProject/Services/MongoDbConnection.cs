using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDbProject.Services
{
    public class MongoDbConnection
    {
        private IMongoDatabase _database;

        public MongoDbConnection()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            _database = client.GetDatabase("ProductListDb");
        }

        public IMongoCollection<BsonDocument> GetProductCollection()
        {
            return _database.GetCollection<BsonDocument>("Product");
        }


    }
}
