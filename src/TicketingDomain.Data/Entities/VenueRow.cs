using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingDomain.Data.Entities
{
    public class VenueRow : BaseEntity
    {
        [Required]
        [ForeignKey("Venue")]
        public Guid VenueId { get; set; }
        public virtual Venue Venue { get; set; }

        [Required]
        [ForeignKey("Row")]
        public Guid RowId { get; set; }
        public virtual Row Row { get; set; }
    }
}
