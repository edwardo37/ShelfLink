using Microsoft.EntityFrameworkCore;

namespace ShelfLink.Models
{
    /// <summary>
    /// Library member class
    /// </summary>
    [Index(nameof(Email), IsUnique=true)]
    public class User : EntityBase
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public required string Address { get; set; }
        public required UserStatus Status { get; set; }
        public required UserRole Role { get; set; }
        // Navigation properties
        public UserFine? Fine { get; set; }
        public List<CopyCheckout> Checkouts { get; } = new List<CopyCheckout>();
        public List<TitleHold> Holds { get; } = new List<TitleHold>();
    }
}
