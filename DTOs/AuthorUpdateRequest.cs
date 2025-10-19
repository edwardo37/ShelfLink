using System.ComponentModel.DataAnnotations;

namespace ShelfLink.DTOs
{
    public class AuthorUpdateRequest
    {
        [Length(1,200)]
        public string? Name { get; set; }
    }
}
