namespace ShelfLink.Models
{
    /// <summary>
    /// Basic abstract base class for all entities. Holds Id, Created and Updated info.
    /// </summary>
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public required Staff CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public required Staff UpdatedBy { get; set; }
    }
}
