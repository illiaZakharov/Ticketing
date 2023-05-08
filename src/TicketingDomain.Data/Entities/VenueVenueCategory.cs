using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingDomain.Data.Entities
{
    public class VenueVenueCategory : BaseEntity
    {
        [Required]
        [ForeignKey("Venue")]
        public Guid VenueId { get; set; }
        public virtual Venue Venue { get; set; }

        [Required]
        [ForeignKey("VenueCategory")]
        public Guid VenueCategoryId { get; set; }

        public virtual VenueCategory VenueCategory { get; set; }
    }
}
