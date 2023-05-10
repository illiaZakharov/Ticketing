using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Persistence.Entities
{
    public class TicketS : BaseEntity
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [ForeignKey(nameof(Seat))]
        public Guid SeatId { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
