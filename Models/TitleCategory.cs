namespace ShelfLink.Models
{
    /// <summary>
    /// Basic class for categories like book, audiobook, etc.
    /// </summary>
    public class TitleCategory : EntityBase
    {
        public required string Name { get; set; }
    }
}
