namespace ShelfLink.DTOs
{
    public class TitleResponse
    {
        public int TitleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = "";
        public string? ISBN { get; set; }
        public DateOnly PublishDate { get; set; }
        public List<int>? AuthorIds { get; set; } = [];
        public List<string>? AuthorNames { get; set; } = [];
        public string? Publisher { get; set; } = "";
        public string? Genre { get; set; } = "";
        public string CategoryName { get; set; } = string.Empty;
    }
}
