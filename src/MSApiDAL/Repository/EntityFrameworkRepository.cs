using MSApiDAL.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSApiDAL.Repository
{
    public class EntityFrameworkRepository<TEntity> : IEntityFrameworkRepository<TEntity> where TEntity : class
    {
        private EntityFrameworkContext<TEntity> _context;
        private DbSet<TEntity> _entities;

        public EntityFrameworkRepository(EntityFrameworkContext<TEntity> context)
        {
            _context = context;
        }

        private DbSet<TEntity> Entities
        {
            get { return _entities ?? (_entities = _context.Set<TEntity>()); }
        }

        public void Insert(List<TEntity> entity)
        {
            Entities.AddRange(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
            _context.SaveChanges();
        }

        public IList<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
