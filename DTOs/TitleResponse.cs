namespace ShelfLink.DTOs
{
    public class TitleResponse
    {
        public int TitleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = "";
        public string? ISBN { get; set; }
        public DateOnly PublishDate { get; set; }
        public List<AuthorResponse> Authors { get; set; } = new List<AuthorResponse>();
        public string? Publisher { get; set; } = "";
        public string? Genre { get; set; } = "";
        public string CategoryName { get; set; } = string.Empty;
    }
}
