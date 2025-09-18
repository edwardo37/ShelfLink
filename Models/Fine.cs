namespace ShelfLink.Models
{
    /// <summary>
    /// Fine issued to a library member. Added automatically when a copy is overdue.
    /// </summary>
    public class Fine : EntityBase
    {
        public required LibraryMember Member { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime DateIssued { get; set; }
        public bool IsPaid { get; set; } = false;
    }
}
