using Microsoft.EntityFrameworkCore;
using ShelfLink.Models;

namespace ShelfLink.Repositories
{
    public class ShelfLinkDbContext : DbContext
    {
        public ShelfLinkDbContext(DbContextOptions<ShelfLinkDbContext> options)
        : base(options) { } 

        public DbSet<Title> Titles { get; set; }
        public DbSet<TitleCategory> Categories { get; set; }
        public DbSet<TitlePublisher> Publisher { get; set; }
        public DbSet<TitleAuthor> Authors { get; set; }
        public DbSet<TitleGenre> Genres { get; set; }

        public DbSet<TitleCopy> Copies { get; set; }
        public DbSet<CopyCheckout> Checkouts { get; set; }
        public DbSet<TitleHold> Holds { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<UserFine> Fines { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<UserStatus> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite PK for Copy Checkout
            modelBuilder.Entity<CopyCheckout>()
                .HasKey(e => new { e.TitleCopyId, e.MemberId });

            // Composite PK for Title Hold
            modelBuilder.Entity<TitleHold>()
                .HasKey(e => new { e.TitleId, e.MemberId });


            // Configure relationships, constraints, etc.
            base.OnModelCreating(modelBuilder);
        }
    }
}
