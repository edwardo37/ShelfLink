using Microsoft.EntityFrameworkCore;

namespace ShelfLink.Models
{
    /// <summary>
    /// Unique title entity. Represents all main inventory in a library.
    /// </summary>
    [Index(nameof(ISBN), IsUnique=true)]
    public class Title : EntityBase
    {
        public int TitleId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ISBN { get; set; }
        public DateOnly PublishDate { get; set; }
        public string? PublisherName { get; set; }
        public string? GenreName { get; set; }
        public required string CategoryName { get; set; }

        // Navigation properties
        public required List<TitleAuthor> Authors { get; set; } = new List<TitleAuthor>();
        public TitlePublisher? Publisher { get; set; }
        public TitleGenre? Genre { get; set; }
        public TitleCategory? Category { get; set; }

        public List<TitleCopy> Copies { get; } = new List<TitleCopy>();
        public List<TitleHold> Holds { get; } = new List<TitleHold>();
    }
}
