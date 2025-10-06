namespace ShelfLink.Models
{
    /// <summary>
    /// Author class with Id and Name
    /// </summary>
    public class TitleAuthor : EntityBase
    {
        public required string Name { get; set; }

        // Navigational properties
        public List<Title> Titles { get; } = new List<Title>();
    }
}
