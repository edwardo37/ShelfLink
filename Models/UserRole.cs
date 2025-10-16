using System.ComponentModel.DataAnnotations;

namespace ShelfLink.Models
{
    /// <summary>
    /// Role of a user (e.g. Admin, User, Guest)
    /// </summary>
    public class UserRole : EntityBase
    {
        [Key]
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
