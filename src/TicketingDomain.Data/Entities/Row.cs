using System.ComponentModel.DataAnnotations;

namespace TicketingDomain.Data.Entities
{
    public class Row : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public virtual ICollection<VenueRow> VenueRows { get; set; }
        public virtual ICollection<RowSeat> RowSeats { get; set; }

        public Row()
        {
            RowSeats = new HashSet<RowSeat>();
            VenueRows = new HashSet<VenueRow>();
        }
    }
}
