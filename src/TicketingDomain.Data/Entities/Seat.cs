using System.ComponentModel.DataAnnotations;

namespace TicketingDomain.Data.Entities
{
    public class Seat : BaseEntity
    {
        [StringLength(200)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int? Number { get; set; }

        [Required]
        [StringLength(200)]
        public string Status { get; set; } // e.g. available, reserved, sold

        [Required]
        [StringLength(200)]
        public string Type { get; set; } // e.g. regular, VIP, wheelchair accessible

        public virtual ICollection<RowSeat> RowSeats { get; set; }
        public virtual Ticket Ticket { get; set; }

        public Seat()
        {
            RowSeats = new HashSet<RowSeat>();
        }
    }
}
