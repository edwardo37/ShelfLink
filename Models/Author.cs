namespace ShelfLink.Models
{
    /// <summary>
    /// Author class with Id and Name
    /// </summary>
    public class Author : EntityBase
    {
        public required string Name { get; set; }
    }
}
