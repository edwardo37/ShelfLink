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

        public TEntity? GetById(int id) => _dbSet.Find(id);
        public IQueryable<TEntity> Query() => _dbSet.AsQueryable();
        public void Add(TEntity entity) => _dbSet.Add(entity);
        public void Update(TEntity entity) => _dbSet.Update(entity);
        public void Delete(TEntity entity) => _dbSet.Remove(entity);
        public void SaveChanges() => _context.SaveChanges();
    }
}
