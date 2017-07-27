using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSApiDAL.Repository
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : class
    {
        IMongoContext<TEntity> _context;

        public MongoRepository(IMongoContext<TEntity> context)
        {
            _context = context;
        }

        public IList<TEntity> GetAll()
        {
            return _context.collection.Find(new BsonDocument()).ToList();
        }

        public async void Upsert(List<TEntity> documents)
        {
             await _context.collection.InsertManyAsync(documents);
        }

        public async void Upsert(TEntity document)
        {
            await _context.collection.InsertOneAsync(document);
        }

        public async Task<List<TEntity>> Get(FilterDefinition<TEntity> filter)
        {
            FindOptions<TEntity> options = new FindOptions<TEntity> { Limit = 10 };
            IAsyncCursor<TEntity> task = await _context.collection.FindAsync(filter, options);
            List<TEntity> list = await task.ToListAsync();
            return list;
        }

        public void Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateResult> Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            return await _context.collection.UpdateOneAsync(filter, update);
        }

        public async Task<DeleteResult> Delete(FilterDefinition<TEntity> filter)
        {
            return await _context.collection.DeleteOneAsync(filter);
        }
    }
}
