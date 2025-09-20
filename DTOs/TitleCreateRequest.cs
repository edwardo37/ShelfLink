using System.ComponentModel.DataAnnotations;

namespace ShelfLink.DTOs
{
    public class TitleCreateRequest
    {
        [Required]
        [Length(1, 200)]
        public string Name { get; set; } = string.Empty;
        [Length(10, 13)]
        public string? ISBN { get; set; }
        [Required]
        public DateOnly PublishDate { get; set; }
        [Required]
        public string Author { get; set; } = string.Empty;
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        [Required]
        public string Category { get; set; } = string.Empty;
    }
}
