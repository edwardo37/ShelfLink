namespace ShelfLink.Models
{
    /// <summary>
    /// Unique title entity. Represents all main inventory in a library.
    /// </summary>
    public class Title : EntityBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ISBN { get; set; }
        public DateOnly PublishDate { get; set; }
        public required int AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int? GenreId { get; set; }
        public required int CategoryId { get; set; }

        // Navigation properties
        public required TitleAuthor Author { get; set; }
        public TitlePublisher? Publisher { get; set; }
        public TitleGenre? Genre { get; set; }
        public required TitleCategory Category { get; set; }

        public List<TitleCopy> Copies { get; } = new List<TitleCopy>();
        public List<TitleHold> Holds { get; } = new List<TitleHold>();
    }
}
