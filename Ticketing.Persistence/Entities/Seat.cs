using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Persistence.Entities
{
    public class Seat : BaseEntity
    {
        [Required]
        public int SeatNumber { get; set; }

        [Required]
        public int RowNumber { get; set; }

        [Required]
        [ForeignKey(nameof(Zone))]
        public Guid ZoneId { get; set; }
        public virtual Zone Zone { get; set; }

        public virtual SeatTicket Ticket { get; set; }
    }
}
