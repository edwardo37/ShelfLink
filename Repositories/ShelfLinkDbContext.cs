using Microsoft.EntityFrameworkCore;
using ShelfLink.Models;

namespace ShelfLink.Repositories
{
    public class ShelfLinkDbContext : DbContext
    {
        public ShelfLinkDbContext(DbContextOptions<ShelfLinkDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<UserStatus> Statuses { get; set; }


        public DbSet<Title> Titles { get; set; }
        public DbSet<TitleAuthor> Authors { get; set; }
        public DbSet<TitlePublisher> Publishers { get; set; }
        public DbSet<TitleGenre> Genres { get; set; }
        public DbSet<TitleCategory> Categories { get; set; }
        public DbSet<TitleCopy> Copies { get; set; }
        public DbSet<TitleHold> Holds { get; set; }
    }
}
