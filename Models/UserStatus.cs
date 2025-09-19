namespace ShelfLink.Models
{
    /// <summary>
    /// Status of a user account (e.g. Active, Inactive, Suspended)
    /// </summary>
    public class UserStatus : EntityBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
