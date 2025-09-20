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
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public string? Category { get; set; }

    }
}
