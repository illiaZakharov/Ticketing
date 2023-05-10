using System.ComponentModel.DataAnnotations;

namespace Ticketing.Persistence.Entities
{
    public class Venue : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public virtual ICollection<Zone> Zones { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

        public Venue()
        {
            Zones = new HashSet<Zone>();
            Offers = new HashSet<Offer>();
        }
    }
}
