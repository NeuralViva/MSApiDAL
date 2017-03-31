namespace MSApiDAL.Repository
{
    public interface IEntityFrameworkRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        void Save(TEntity model);
        void Delete(int id);
    }
}
