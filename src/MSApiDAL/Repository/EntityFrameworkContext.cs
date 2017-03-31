using Microsoft.EntityFrameworkCore;

namespace MSApiDAL.EntityFramework
{
    public class EntityFrameworkContext<TEntity> : DbContext where TEntity : class
    {
        public EntityFrameworkContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TEntity> collection { get; set; }
    }
}
