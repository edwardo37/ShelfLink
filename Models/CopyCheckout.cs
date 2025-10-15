namespace ShelfLink.Models
{
    /// <summary>
    /// Checkout of a title copy by a library member
    /// </summary>
    public class CopyCheckout : EntityBase
    {
        // Composite PK
        public required int TitleCopyId { get; set; }
        public required int MemberId { get; set; }


        public required DateTime DueDate { get; set; }


        // Navigation properties
        public required TitleCopy Copy { get; set; }
        public required User Member { get; set; }
    }
}
