using System.ComponentModel.DataAnnotations;

namespace ShelfLink.DTOs
{
    public class TitleUpdateRequest
    {
        [Length(1,200)]
        public string? Name { get; set; }
        [Length(10,13)]
        public string? ISBN { get; set; }
        public DateOnly? PublishDate { get; set; }
        public List<int>? AuthorIds { get; set; }
        public string? PublisherName { get; set; }
        public string? GenreName { get; set; }
        public string? CategoryName { get; set; }

    }
}
