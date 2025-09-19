namespace ShelfLink.Models
{
    /// <summary>
    /// Copy of a title in the inventory. Each title can have multiple copies.
    /// </summary>
    public class TitleCopy : EntityBase
    {
        public required Title Title { get; set; }
        public string? Location { get; set; }
        public string? Barcode { get; set; }

        public CopyCheckout? copyCheckout { get; }
    }
}
