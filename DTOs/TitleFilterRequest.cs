using System.ComponentModel.DataAnnotations;

namespace ShelfLink.DTOs
{
    public class TitleFilterRequest
    {
        [Length(1, 200)]
        public string Name { get; set; } = string.Empty;
        [Length(10, 13)]
        public string ISBN { get; set; } = string.Empty;
        public DateOnly? PublishDate { get; set; } = null;
        public List<string> Authors { get; set; } = [];
        public string Publisher { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
