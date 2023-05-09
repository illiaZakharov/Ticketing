using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingDomain.Data.Entities
{
    public class RowSeat: BaseEntity
    {
        [Required]
        [ForeignKey("Row")]
        public Guid RowId { get; set; }
        public virtual Row Row { get; set; }

        [Required]
        [ForeignKey("Seat")]
        public Guid SeatId { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
