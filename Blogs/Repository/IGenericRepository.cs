using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Repository
{
    /// <summary>
    /// Repository which encapsulate work with database
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);

        TEntity GetEntity(int id);
        IEnumerable<TEntity> GetAll();

        /// Need for additional conditions for db query
        IQueryable<TEntity> GetQuery();

        void Delete(int id);
        void Delete(TEntity item);

        void Update(TEntity item);
    }
}
