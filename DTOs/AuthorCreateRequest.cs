using System.ComponentModel.DataAnnotations;

namespace ShelfLink.DTOs
{
    public class AuthorCreateRequest
    {
        [Required]
        [Length(1,200)]
        public required string Name { get; set; }
    }
}
