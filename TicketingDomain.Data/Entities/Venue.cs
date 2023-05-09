using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingDomain.Data.Entities
{
    public class Venue : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [ForeignKey("Location")]
        public Guid LocationId { get; set; }
        public virtual Address Location { get; set; }

        public virtual ICollection<VenueVenueCategory> VenueVenueCategories { get; set; }
        public virtual ICollection<VenueRow> VenueRows { get; set; }
        public virtual Event Event { get; set; }

        public Venue() 
        {
            VenueVenueCategories = new HashSet<VenueVenueCategory>();
            VenueRows = new HashSet<VenueRow>();
        }
    }

}
