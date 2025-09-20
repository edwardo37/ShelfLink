namespace ShelfLink.Models
{
    /// <summary>
    /// Copy of a title in the inventory. Each title can have multiple copies.
    /// </summary>
    public class TitleCopy : EntityBase
    {
        public required int TitleId { get; set; }
        public int? CopyCheckoutId { get; set; }
        public string? Location { get; set; }
        public string? Barcode { get; set; }
        // Navigation properties
        public required Title Title { get; set; }
        public CopyCheckout? copyCheckout { get; }
    }
}
