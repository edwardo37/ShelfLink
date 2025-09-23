namespace ShelfLink.Models
{
    /// <summary>
    /// Library member class
    /// </summary>
    public class User : EntityBase
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public required string Address { get; set; }
        public required UserStatus Status { get; set; }
        public required UserRole Role { get; set; }
        // Navigation properties
        public List<CopyCheckout> Checkouts { get; } = new List<CopyCheckout>();
        public List<TitleHold> Holds { get; } = new List<TitleHold>();
    }
}
