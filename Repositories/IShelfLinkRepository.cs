using Microsoft.EntityFrameworkCore;
using ShelfLink.Models;

namespace ShelfLink.Repositories
{
    /// <summary>
    /// Interface definining ShelfLink repository
    /// </summary>
    public interface IShelfLinkRepository<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// Get an entity by its unique identifier
        /// </summary>
        /// <param name="id">The Id of the entity to fetch</param>
        /// <returns>The entity, null if not found</returns>
        public TEntity? GetById(int id);
        /// <summary>
        /// Generic query function for the service layer
        /// </summary>
        /// <returns>A queryable version of the DbSet</returns>
        public IQueryable<TEntity> Query();
        /// <summary>
        /// Add an entity to the DB. Saves changes must be called to persist
        /// </summary>
        /// <param name="entity">The entity to add</param>
        public void Add(TEntity entity);
        /// <summary>
        /// Update an entity in the DB. Saves changes must be called to persist
        /// </summary>
        /// <param name="entity">The entity to update</param>
        public void Update(TEntity entity);
        /// <summary>
        /// Delete an entity from the DB. Saves changes must be called to persist
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity);
        /// <summary>
        /// Save tracked changes to the DB
        /// </summary>
        public void SaveChanges();
    }
}
