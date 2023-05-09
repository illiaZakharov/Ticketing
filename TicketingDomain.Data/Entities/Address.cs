using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingDomain.Data.Entities
{
    public class Address : BaseEntity
    {
        [StringLength(200)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(200)]
        public string AddressLine { get; set; }

        public virtual Venue Venue { get; set; }
    }
}
