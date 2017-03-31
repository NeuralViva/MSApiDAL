using MongoDB.Driver;

namespace MSApiDAL.Repository
{
    public interface IMongoContext<TEntity> where TEntity : class
    {
        IMongoCollection<TEntity> collection { get; }
    }
}