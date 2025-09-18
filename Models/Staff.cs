namespace ShelfLink.Models
{
    /// <summary>
    /// Staff member model. Has name and role.
    /// </summary>
    public class Staff : EntityBase
    {
        public required string Name { get; set; }
        public required string Role { get; set; }
        public required string Status { get; set; }
    }
}
