using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Persistence.Entities
{
    public class Offer : BaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [ForeignKey(nameof(Venue))]
        public Guid VenueId { get; set; }
        public virtual Venue Venue { get; set; }

        [Required]
        [ForeignKey(nameof(Event))]
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }

        public virtual ICollection<SeatTicket> SeatTickets { get; set; }
        public virtual ICollection<GeneralAdmissionTicket> GeneralAdmissionTickets { get; set; }

        public Offer()
        {
            SeatTickets = new HashSet<SeatTicket>();
            GeneralAdmissionTickets = new HashSet<GeneralAdmissionTicket>();
        }
    }
}
