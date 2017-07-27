using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSApiDAL.Repository
{
    public interface IMongoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> Get(FilterDefinition<TEntity> filter);
        void Upsert(List<TEntity> documents);
        void Upsert(TEntity document);
        Task<DeleteResult> Delete(FilterDefinition<TEntity> filter);
        Task<UpdateResult> Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);
    }
}
