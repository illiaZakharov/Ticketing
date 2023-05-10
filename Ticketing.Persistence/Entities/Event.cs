using System.ComponentModel.DataAnnotations;

namespace Ticketing.Persistence.Entities
{
    public class Event : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public DateTime EventDateTime { get; set; }

        [Required]
        public int Duration { get; set; }

        public virtual Offer Offer { get; set; }
    }
}
