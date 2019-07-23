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
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Add new item to db
        /// </summary>
        /// <param name="item"></param>
        void Create(TEntity item);

        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetEntity(int id);
        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// Need for additional conditions for db query
        IQueryable<TEntity> GetQuery();

        /// <summary>
        /// Delete item by id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item"></param>
        void Delete(TEntity item);

        /// <summary>
        /// Edit item
        /// </summary>
        /// <param name="item"></param>
        void Update(TEntity item);

        /// <summary>
        /// Is item exist in this db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Contains(int id);
    }
}
