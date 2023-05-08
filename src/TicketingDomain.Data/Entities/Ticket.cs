using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingDomain.Data.Entities
{
    public class Ticket : BaseEntity
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("Event")]
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }

        [Required]
        [ForeignKey("Seat")]
        public Guid SeatId { get; set; }
        public virtual Seat Seat { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [ForeignKey("Payment")]
        public Guid PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
