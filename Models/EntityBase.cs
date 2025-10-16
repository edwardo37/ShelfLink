using System.Text.Json.Serialization;

namespace ShelfLink.Models
{
    /// <summary>
    /// Basic abstract base class for all entities. Holds Id, Created and Updated info.
    /// </summary>
    public abstract class EntityBase
    {
        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public int? CreatedByUserId { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public int? UpdatedByUserId { get; set; }
    }
}
