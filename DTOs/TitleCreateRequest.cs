using System.ComponentModel.DataAnnotations;

namespace ShelfLink.DTOs
{
    public class TitleCreateRequest
    {
        [Required]
        [Length(1, 200)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        [Length(10, 13)]
        public string? ISBN { get; set; }
        [Required]
        public DateOnly PublishDate { get; set; }
        [Required]
        public List<int> AuthorIds { get; set; } = [];
        public string? PublisherName { get; set; }
        public string? GenreName { get; set; }
        [Required]
        public string CategoryName { get; set; } = "";
    }
}
