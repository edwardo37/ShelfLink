using Microsoft.EntityFrameworkCore;
using ShelfLink.Models;

namespace ShelfLink.Repositories
{
    public class ShelfLinkRepoEfImpl<TEntity> : IShelfLinkRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ShelfLinkDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public ShelfLinkRepoEfImpl(ShelfLinkDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var addedEntity = _context.Set<TEntity>().Add(entity).Entity;
            _context.SaveChanges();
            return addedEntity;
        }

        public TEntity? GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity? ApplyUpdate(TEntity entity)
        {
            // Get existing entity and check exists
            var existingEntity = GetById(entity.Id);
            if (existingEntity == null)
            {
                return null;
            }

            // Update and save
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return existingEntity;
        }

        public List<TEntity> GetListByFilterPaged(Func<IQueryable<TEntity>, IQueryable<TEntity>> filterQuery, int page, int pageSize)
        {
            // Apply the query to a filter
            var query = filterQuery(_dbSet.AsQueryable());

            // Apply pagination and return
            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public bool Delete(int id)
        {
            // Get entity and check exists
            var entity = GetById(id);
            if (entity == null)
            {
                return false;
            }

            // Remove and save
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
