using System.Collections.Generic;

namespace MSApiDAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
    }
}
