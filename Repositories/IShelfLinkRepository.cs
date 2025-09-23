using ShelfLink.DTOs;
using ShelfLink.Models;

namespace ShelfLink.Repositories
{
    /// <summary>
    /// Interface definining ShelfLink repository
    /// </summary>
    public interface IShelfLinkRepository<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// Add a new entity to the repository
        /// </summary>
        /// <param name="entity">The entity to save</param>
        /// <returns>The newly-saved entity, with EntityBase updated</returns>
        TEntity Add(TEntity entity);
        /// <summary>
        /// Get an entity by its unique Id
        /// </summary>
        /// <param name="id">The Id of the entity to fetch</param>
        /// <returns>The fetched entity, null if not found</returns>
        TEntity? GetById(int id);
        /// <summary>
        /// Update an entity in the repository
        /// </summary>
        /// <param name="entity">The entity to base the update on</param>
        /// <returns>The newly-updated entity, null if not found</returns>
        TEntity? ApplyUpdate(TEntity entity);
        /// <summary>
        /// Get a list of entities based on a filter query, with pagination
        /// </summary>
        /// <param name="filterQuery">The query lambda to run</param>
        /// <param name="page">The current page</param>
        /// <param name="pageSize">The size of each page</param>
        /// <returns>A list of applicable entites</returns>
        List<TEntity> GetListByFilterPaged(Func<IQueryable<TEntity>, IQueryable<TEntity>> filterQuery, int page, int pageSize);
        /// <summary>
        /// Delete an entity by its unique Id
        /// </summary>
        /// <param name="id">The Id of the entity to delete</param>
        /// <returns>Bool indicating status, false if not found</returns>
        bool Delete(int id);
    }
}
