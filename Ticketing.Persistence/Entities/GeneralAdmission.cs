using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Persistence.Entities
{
    public class GeneralAdmission : BaseEntity
    {
        [Required]
        public int MaxQuantity { get; set; }

        [Required]
        [ForeignKey(nameof(Zone))]
        public Guid ZoneId { get; set; }
        public virtual Zone Zone { get; set; }

        public virtual ICollection<TicketGA> Tickets { get; set; }

        public GeneralAdmission()
        {
            Tickets = new HashSet<TicketGA>();
        }
    }
}
