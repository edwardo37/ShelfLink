using Microsoft.EntityFrameworkCore;
using ShelfLink.Models;

namespace ShelfLink.Repositories
{
    public class ShelfLinkDbContext : DbContext
    {
        public ShelfLinkDbContext(DbContextOptions<ShelfLinkDbContext> options) : base(options) { }
    }
}
