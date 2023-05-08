using System.ComponentModel.DataAnnotations;
namespace TicketingDomain.Data.Entities
{
    public class VenueCategory : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
 
        [StringLength(500)]
        public string? Description { get; set; }

        public virtual ICollection<VenueVenueCategory> VenueVenueCategories { get; set; }

        public VenueCategory() 
        {
            VenueVenueCategories = new HashSet<VenueVenueCategory>();
        }
    }
}
