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
        // TODO: Add constraints
        public required string Status { get; set; }
        public required string Role { get; set; }
    }
}
