using System.ComponentModel.DataAnnotations;

namespace ShelfLink.Models
{
    /// <summary>
    /// Basic class representing genres
    /// </summary>
    public class TitleGenre : EntityBase
    {
        [Key]
        public required string Name { get; set; }
    }
}
