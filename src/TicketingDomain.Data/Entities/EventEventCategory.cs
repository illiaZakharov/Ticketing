using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingDomain.Data.Entities
{
    public class EventEventCategory : BaseEntity
    {
        [Required]
        [ForeignKey("Event")]
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }

        [Required]
        [ForeignKey("EventCategory")]
        public Guid EventCategoryId { get; set; }
        public virtual EventCategory EventCategory { get; set; }
    }
}
