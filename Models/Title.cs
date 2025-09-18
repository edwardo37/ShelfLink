namespace ShelfLink.Models
{
    /// <summary>
    /// Unique title entity. Represents all main inventory in a library.
    /// </summary>
    public class Title : EntityBase
    {
        public required TitleCategory Category { get; set; }
        public required string Name { get; set; }
        public TitleGenre? Genre { get; set; }
        public string? ISBN { get; set; }
        public DateOnly PublishDate { get; set; }

        // Navigation properties
        public List<TitleCopy> Copies { get; } = new List<TitleCopy>();
    }
}
