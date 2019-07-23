using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Repository
{
    public class Repository<TEntity> : IGenericRepository<TEntity> 
        where TEntity : class
    {
        private readonly DbSet<TEntity> dbSet;
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public bool Contains(int id)
        {
            return GetEntity(id) != null;
        }

        public void Create(TEntity item)
        {
            this.dbSet.Add(item);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetEntity(id);
            if (item == null) throw new NullReferenceException($"There is no object with '{id}' id");

            Delete(item);
        }   

        public void Delete(TEntity item)
        {
            this.dbSet.Remove(item);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.dbSet.AsNoTracking().AsEnumerable();
        }

        public TEntity GetEntity(int id)
        {
            return this.dbSet.Find(id);
        }

        public IQueryable<TEntity> GetQuery()
        {
            return this.dbSet.AsNoTracking();
        }

        public void Update(TEntity item)
        {
            this.context.Entry(item).State = EntityState.Modified;
            this.dbSet.Update(item);
            this.context.SaveChanges();
        }
    }
}
