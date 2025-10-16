using System.ComponentModel.DataAnnotations;

namespace ShelfLink.Models
{
    /// <summary>
    /// Publisher class with Id and Name
    /// </summary>
    public class TitlePublisher : EntityBase
    {
        [Key]
        public required string Name { get; set; }

        // Navigational properties
        public List<Title> Titles { get; set; } = [];
    }
}
