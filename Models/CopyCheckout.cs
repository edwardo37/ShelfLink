namespace ShelfLink.Models
{
    /// <summary>
    /// Checkout of a title copy by a library member
    /// </summary>
    public class CopyCheckout : EntityBase
    {
        public required TitleCopy Copy { get; set; }
        public required LibraryMember Member { get; set; }
        public required DateTime DueDate { get; set; }
    }
}
