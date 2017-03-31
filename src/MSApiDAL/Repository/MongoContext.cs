using MSApiDAL.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MSApiDAL.Repository
{
    public class MongoContext<TEntity> : IMongoContext<TEntity> where TEntity : class
    {
        private readonly IMongoDatabase _database = null;
        private IOptions<DatabaseOptions> _settings;

        public MongoContext(IOptions<DatabaseOptions> settings)
        {
            _settings = settings;
            var client = new MongoClient(_settings.Value.MongoConnectionString);
            if (client != null)
                _database = client.GetDatabase(_settings.Value.MongoDatabaseName);
        }

        public IMongoCollection<TEntity> collection =>  _database.GetCollection<TEntity>(_settings.Value.MongoCollectionName);
    }
}
