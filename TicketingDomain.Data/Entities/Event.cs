using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingDomain.Data.Entities
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

        [Required]
        [ForeignKey("Venue")]
        public Guid VenueId { get; set; }
        public virtual Venue Venue { get; set; }

        public virtual ICollection<EventEventCategory> EventEventCategories { get; set; }
        public virtual Ticket Ticket { get; set; }

        public Event() 
        {
            EventEventCategories = new HashSet<EventEventCategory>();
        }

    }
}
