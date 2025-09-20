namespace ShelfLink.Models
{
    /// <summary>
    /// Hold placed on a title by a library member
    /// </summary>
    public class TitleHold : EntityBase
    {
        public required int TitleId { get; set; }
        public required int MemberId { get; set; }
        public required DateTime HoldPlaced { get; set; }
        // Navigation properties
        public required Title Title { get; set; }
        public required User Member { get; set; }
    }
}
