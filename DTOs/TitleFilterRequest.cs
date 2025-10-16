using System.ComponentModel.DataAnnotations;

namespace ShelfLink.DTOs
{
    public class TitleFilterRequest
    {
        [Length(1, 200)]
        public string Name { get; set; } = string.Empty;
        [Length(10, 13)]
        public string ISBN { get; set; } = string.Empty;
        public int? PublishYear { get; set; } = null;
        public List<int> AuthorIds { get; set; } = [];
        public string? PublisherName { get; set; }
        public string? GenreName { get; set; }
        public string? CategoryName { get; set; }
    }
}
