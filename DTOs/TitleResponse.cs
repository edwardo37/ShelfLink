namespace ShelfLink.DTOs
{
    public class TitleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ISBN { get; set; }
        public DateOnly PublishDate { get; set; }
        public string Author { get; set; } = string.Empty;
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
