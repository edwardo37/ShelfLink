using System.ComponentModel.DataAnnotations;

namespace ShelfLink.DTOs
{
    public class AuthorFilterRequest
    {
        [Length(1, 200)]
        public string? Name { get; set; } = string.Empty;
    }
}
