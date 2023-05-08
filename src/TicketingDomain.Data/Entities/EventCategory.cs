using System.ComponentModel.DataAnnotations;

namespace TicketingDomain.Data.Entities
{
    public class EventCategory : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }

        public virtual ICollection<EventEventCategory> EventEventCategories { get; set; }

        public EventCategory()
        {
            EventEventCategories = new HashSet<EventEventCategory>();
        }
    }
}
