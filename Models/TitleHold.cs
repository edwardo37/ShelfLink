namespace ShelfLink.Models
{
    /// <summary>
    /// Hold placed on a title by a library member
    /// </summary>
    public class TitleHold : EntityBase
    {
        public required Title Title { get; set; }
        public required LibraryMember Member { get; set; }
        public required DateTime HoldPlaced { get; set; }
    }
}
