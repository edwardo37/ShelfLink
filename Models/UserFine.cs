namespace ShelfLink.Models
{
    /// <summary>
    /// Fine issued to a library member. Added automatically when a copy is overdue.
    /// </summary>
    public class UserFine : EntityBase
    {
        [Key]
        public required int UserId { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime DateIssued { get; set; }
        public bool IsPaid { get; set; } = false;
        // Navigation properties
        public required User Member { get; set; }
    }
}
