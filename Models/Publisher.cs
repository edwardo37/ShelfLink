namespace ShelfLink.Models
{
    /// <summary>
    /// Publisher class with Id and Name
    /// </summary>
    public class Publisher : EntityBase
    {
        public required string Name { get; set; }
    }
}
